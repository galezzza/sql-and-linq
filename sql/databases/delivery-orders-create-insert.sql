/*
Pro SQL Server Internals
APress. 2nd Edition. ISBN-13: 978-1484219638 ISBN-10:1484219635
Database creation script (fragment)
Written by Dmitri V. Korotkevitch
http://aboutsqlserver.com
dk@aboutsqlserver.com 
*/

DROP TABLE IF EXISTS DeliveryOrders;

CREATE TABLE DeliveryOrders
(
    OrderId           INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    OrderDate         TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    OrderNum          VARCHAR(20) NOT NULL,
    Reference         VARCHAR(64),
    CustomerId        INT NOT NULL,
    PickupAddressId   INT NOT NULL,
    DeliveryAddressId INT NOT NULL,
    ServiceId         INT NOT NULL,
    RatePlanId        INT NOT NULL,
    OrderStatusId     INT NOT NULL,
    DriverId          INT,
    Pieces            SMALLINT NOT NULL,
    Amount            MONEY NOT NULL,
    ModTime           TIMESTAMP WITHOUT TIME ZONE NOT NULL
                      DEFAULT CURRENT_TIMESTAMP,
    PlaceHolder       CHAR(100) NOT NULL
                      DEFAULT 'Placeholder'
);

DO $$
DECLARE
    MaxOrderId   INT := 65536;
    MaxCustomers INT := 1000;
    MaxAddresses INT := 20;
    MaxDrivers   INT := 125;
BEGIN

WITH RECURSIVE
N1 AS (
    SELECT 0 AS c
    UNION ALL
    SELECT 0 FROM generate_series(1, 1)
),
N2 AS (
    SELECT 0 FROM N1 t1 CROSS JOIN N1 t2
),
N3 AS (
    SELECT 0 FROM N2 t1 CROSS JOIN N2 t2
),
N4 AS (
    SELECT 0 FROM N3 t1 CROSS JOIN N3 t2
),
N5 AS (
    SELECT 0 FROM N4 t1 CROSS JOIN N4 t2 LIMIT MaxOrderId
),
IDs AS (
    SELECT ROW_NUMBER() OVER() AS id FROM N5
),
Info AS (
    SELECT
        id AS OrderId,
        (id % MaxCustomers) + 1 AS CustomerId,
        (id % (365 * 24 * 60)) AS OrderDateOffset,
        (id % 2) + 1 AS RatePlanId,
        (id % 3) + 1 AS ServiceId,
        (id % 5) + 1 AS Pieces
    FROM IDs
),
Info2 AS (
    SELECT
        OrderId,
        CURRENT_TIMESTAMP - (OrderDateOffset || ' minutes')::INTERVAL AS OrderDate,
        OrderId::TEXT AS OrderNum,
        CustomerId,
        RatePlanId,
        ServiceId,
        Pieces,
        ((CustomerId - 1) * MaxAddresses + OrderId % 20) AS PickupAddressId,
        CASE
            WHEN OrderDateOffset > 5 * 24 * 60 THEN 4
            ELSE (OrderId % 4) + 1
        END AS OrderStatusId,
        ((OrderId % 5) + 1) * 10.0 AS Rate
    FROM Info
)
INSERT INTO DeliveryOrders
(OrderDate, OrderNum, CustomerId, PickupAddressId, DeliveryAddressId,
 ServiceId, RatePlanId, OrderStatusId, DriverId, Pieces, Amount)
SELECT
    o.OrderDate,
    o.OrderNum,
    o.CustomerId,
    o.PickupAddressId,
    CASE
        WHEN (o.PickupAddressId % MaxAddresses) = 0
        THEN o.PickupAddressId + 1
        ELSE o.PickupAddressId - 1
    END AS DeliveryAddressId,
    o.ServiceId,
    o.RatePlanId,
    o.OrderStatusId,
    CASE
        WHEN o.OrderStatusId IN (1, 4)
        THEN NULL
        ELSE (OrderId % MaxDrivers) + 1
    END AS DriverId,
    o.Pieces,
    o.Rate
FROM Info2 o;


RAISE NOTICE 'First 100 rows:';
PERFORM * FROM DeliveryOrders LIMIT 100;

END $$

SELECT * FROM DeliveryOrders;