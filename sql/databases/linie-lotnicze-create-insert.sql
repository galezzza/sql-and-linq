--USE master;
--DROP DATABASE Linie_Lotnicze;
--GO

--CREATE DATABASE Linie_Lotnicze;
--GO

--USE Linie_Lotnicze;
--GO

------------ USUŃ TABELE ------------

DROP TABLE IF EXISTS Loty;


------------ CREATE - UTWÓRZ TABELE I POWIĄZANIA ------------

CREATE TABLE Loty
(
    linie     VARCHAR(3),
    zkad         VARCHAR(3),
    dokad        VARCHAR(3),
    odloty    TIME(0),
    przyloty  TIME(0)
);


------------ INSERT - WSTAW DANE ------------

INSERT INTO Loty VALUES
('PLL', 'GDA', 'WAR', '09:30', '12:30'), 
('ZLL', 'GDA', 'WRO', '09:00', '14:30'),
('PLL', 'WAR', 'KRA', '15:00', '18:00'),
('PLL', 'WAR', 'WRO', '14:00', '17:00'),
('ZLL', 'WRO', 'KRA', '15:30', '17:30'),
('ZLL', 'WRO', 'POZ', '15:00', '19:30'),
('ZLL', 'KRA', 'POZ', '19:00', '22:00'),
('PLL', 'KRA', 'POZ', '18:30', '21:30');

------------ SELECT ------------

SELECT * FROM Loty;
