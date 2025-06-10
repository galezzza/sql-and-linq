DROP TABLE IF EXISTS Udzial;
DROP TABLE IF EXISTS Uczestnicy;
DROP TABLE IF EXISTS Kursy;
DROP TABLE IF EXISTS MapujMiasta;
DROP TABLE IF EXISTS UczestnicyAktualnie;


CREATE TABLE Uczestnicy (
    PESEL      CHAR(11) PRIMARY KEY,
    nazwisko   VARCHAR(20) NOT NULL,
    miasto     VARCHAR(20) DEFAULT 'Poznań',
    email      VARCHAR(100),
    CONSTRAINT ck_uczestnicy_pesel CHECK (PESEL ~ '^[0-9]{11}$')
);


CREATE TABLE Kursy (
    Kod        SERIAL PRIMARY KEY, -- PostgreSQL не поддерживает IDENTITY, используем SERIAL
    nazwa      VARCHAR(50) UNIQUE,
    liczba_dni INT CHECK (liczba_dni BETWEEN 1 AND 5)
);


CREATE TABLE Udzial (
    uczestnik  CHAR(11) REFERENCES Uczestnicy(PESEL),
    kurs       INT REFERENCES Kursy(Kod),
    data_od    DATE,
    data_do    DATE,
    status     VARCHAR(20),
    CONSTRAINT ck_udzial_status CHECK (status IN ('w trakcie', 'ukonczony', 'nieukonczony')),
    CONSTRAINT ck_udzial_data CHECK (data_do IS NULL OR data_do > data_od)
);


INSERT INTO Kursy(nazwa, liczba_dni) VALUES
('Administracja MySQL'         , 3),
('Analiza danych'              , 3),
('MS Access (zaawansowany)'    , 2),
('MySQL dla programistów'      , 2),
('Programowanie VBA w Accessie', 1);


INSERT INTO Uczestnicy VALUES
('91122895863', 'Lewicka',    'Poznań',         'alewi91@buziaczek.pl'),
('74080812482', 'Kowalski',   'Szczecin',       'kowal@cloud.net'),
('58100387129', 'Najgebauer', 'Lodz',           'jakub@najgebauer.com.pl'),
('69091729555', 'Muszka',     'P-ń',            'muszka@wp.pl'),
('83060448424', 'Jakubowicz', 'Bielskobiała',   'hulk@marvel.com'),
('90121298347', 'Janicka',    'Bielsko Biala',  'janicka@amu.edu.pl');


INSERT INTO Udzial VALUES
('91122895863', (SELECT Kod FROM Kursy WHERE nazwa = 'Administracja MySQL'), '2015-03-01', '2015-03-03', 'ukonczony'),
('83060448424', (SELECT Kod FROM Kursy WHERE nazwa = 'MS Access (zaawansowany)'), '2015-10-12', '2015-10-13', 'nieukonczony'),
('83060448424', (SELECT Kod FROM Kursy WHERE nazwa = 'Analiza danych'), '2017-11-15', NULL, 'w trakcie'),
('91122895863', (SELECT Kod FROM Kursy WHERE nazwa = 'MySQL dla programistów'), '2014-02-22', '2014-02-23', 'nieukonczony'),
('69091729555', (SELECT Kod FROM Kursy WHERE nazwa = 'Administracja MySQL'), '2015-03-01', '2015-03-03', 'ukonczony');


CREATE TABLE MapujMiasta (
    forma_poprawna    VARCHAR(20),
    forma_niepoprawna VARCHAR(20)
);


CREATE TABLE UczestnicyAktualnie (
    PESEL      CHAR(11) PRIMARY KEY,
    nazwisko   VARCHAR(20) NOT NULL,
    miasto     VARCHAR(20) DEFAULT 'Poznań',
    email      VARCHAR(100)
);


INSERT INTO MapujMiasta VALUES
('Poznań',        'Poznan'),
('Poznań',        'P-ń'),
('Kraków',        'Krakow'),
('Łódź',          'Lodz'),
('Bielsko-Biała', 'Bielsko-Biala'),
('Bielsko-Biała', 'Bielsko Biala'),
('Bielsko-Biała', 'Bielsko Biała');


INSERT INTO UczestnicyAktualnie VALUES
('91122895863', 'Lewicka',           'Poznań',        'alewi91@buziaczek.pl'),
('74080812482', 'Kowalski',          'Warszawa',      'kowal@cloud.net'),
('58100387129', 'Najgebauer',        'Lodz',          'jakub@najgebauer.com.pl'),
('69091729555', 'Muszka',            'Poznań',        'muszka@wp.pl'),
('83060448424', 'Jakubowicz',        'Bielsko-Biała', 'hulk@marvel.com'),
('90121298347', 'Janicka-Wolska',    'Bielsko-Biała', 'janicka@amu.edu.pl'),
('81080803031', 'Nowak',             'Mosina',        'nowakjan@gmail.com');

SELECT * FROM Uczestnicy;
SELECT * FROM Kursy;
SELECT * FROM Udzial;
SELECT * FROM MapujMiasta;
SELECT * FROM UczestnicyAktualnie;
