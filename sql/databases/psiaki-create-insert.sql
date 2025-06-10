CREATE TABLE Psiaki_A
(
    pies_kod             INT PRIMARY KEY,
    pies_imie            VARCHAR(10),
    buda                 VARCHAR(10),
    sztuczki_kod_1       INT,
    sztuczki_kod_2       INT,
    sztuczki_kod_3       INT,
    sztuczki_nazwa_1     VARCHAR(15),
    sztuczki_nazwa_2     VARCHAR(15),
    sztuczki_nazwa_3     VARCHAR(15),
    sztuczki_zrecznosc_1 INT,
    sztuczki_zrecznosc_2 INT,
    sztuczki_zrecznosc_3 INT
);

INSERT INTO Psiaki_A VALUES
(1, 'Jackie',  'zielona',   2, NULL, NULL, 'podanie łapy', NULL,           NULL,    8, NULL, NULL),
(2, 'Fourier', 'czerwona',  1,    4, NULL, 'zdechły pies', 'ukłon',        NULL,    6, 4,    NULL),
(3, 'Reksio',  'żółta',     2,    3, NULL, 'podanie łapy', 'turlanie',     NULL,    7, 9,    NULL),
(4, 'Killer',  'niebieska', 2,    3,    4, 'podanie łapy', 'turlanie',     'ukłon', 8, 2,    6),
(5, 'Hańba',   'czerwona',  3,    2, NULL, 'turlanie',     'podanie łapy', NULL,    8, 3,    NULL);

------------------------------------------------------------------------

CREATE TABLE Psiaki_B
(
    pies_kod           INT,
    pies_imie          VARCHAR(10),
    buda               VARCHAR(10),
    sztuczki_kod       INT,
    sztuczki_nazwa     VARCHAR(15),
    sztuczki_zrecznosc INT,
    CONSTRAINT pk_psiaki_b PRIMARY KEY (pies_kod, sztuczki_kod)
);

INSERT INTO Psiaki_B VALUES
(1, 'Jackie',  'zielona',   2, 'podanie łapy', 8),
(2, 'Fourier', 'czerwona',  1, 'zdechły pies', 6),
(2, 'Fourier', 'czerwona',  4, 'ukłon'       , 4),
(3, 'Reksio',  'żółta',     2, 'podanie łapy', 7),
(3, 'Reksio',  'żółta',     3, 'turlanie'    , 9),
(4, 'Killer',  'niebieska', 2, 'podanie łapy', 8),
(4, 'Killer',  'niebieska', 3, 'turlanie'    , 2),
(4, 'Killer',  'niebieska', 4, 'ukłon'       , 6),
(5, 'Hanba',   'czerwona',  3, 'turlanie'    , 8),
(5, 'Hanba',   'czerwona',  2, 'podanie łapy', 3);

------------------------------------------------------------------------

CREATE TABLE Psiaki_C_Psy
(
    pies_kod           INT PRIMARY KEY,
    pies_imie          VARCHAR(10),
    buda               VARCHAR(10)
);

CREATE TABLE Psiaki_C_Sztuczki
(
    sztuczki_kod       INT PRIMARY KEY,
    sztuczki_nazwa     VARCHAR(15)
);

CREATE TABLE Psiaki_C_Zrecznosci
(
    pies_kod           INT REFERENCES Psiaki_C_Psy(pies_kod),
    sztuczki_kod       INT REFERENCES Psiaki_C_Sztuczki(sztuczki_kod),
    sztuczki_zrecznosc INT,
    CONSTRAINT pk_psiaki_c_zrecznosc PRIMARY KEY
    (pies_kod, sztuczki_kod, sztuczki_zrecznosc)
);

INSERT INTO Psiaki_C_Psy VALUES
(1, 'Jackie',  'zielona'),
(2, 'Fourier', 'czerwona'),
(3, 'Reksio',  'żółta'),
(4, 'Killer',  'niebieska'),
(5, 'Hańba',   'czerwona');

INSERT INTO Psiaki_C_Sztuczki VALUES
(1, 'zdechły pies'),
(2, 'podanie łapy'),
(3, 'turlanie'),
(4, 'ukłon');

INSERT INTO Psiaki_C_Zrecznosci VALUES
(1, 2, 8),
(2, 1, 6),
(2, 4, 4),
(3, 2, 7),
(3, 3, 9),
(4, 2, 8),
(4, 3, 2),
(4, 4, 6),
(5, 3, 8),
(5, 2, 3);