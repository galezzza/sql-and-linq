-- task 1
SELECT id, nazwa, stawka
FROM Projekty;

-- task 2
select * from projekty

-- task 3
select 	nazwa as "nazwa stanowiska",
		placa_min as "placa minimalna"
from stanowiska

-- task 4
select 	nazwa, 
		length(nazwa) AS "liczba znaków"
FROM stanowiska;

--task 5
SELECT 	nazwisko,
		placa * 12 as "roczny przychód z pensji"
from pracownicy

--task 6
select 	nazwisko,
		extract(year from age(NOW(),zatrudniony)) * 12 +
		extract(month from age(NOW(),zatrudniony)) 
			as "mies. zatrudniony"
FROM pracownicy

--task 7
SELECT 	nazwisko, 
       	(placa + COALESCE(dod_funkc, '0'::money)) * 12
	   		AS "roczne wynagrodzenie"
FROM   Pracownicy;

-- task 8
select 	nazwa,
		coalesce(datazakonczfakt, NOW()) - datarozp 
			AS "czas trwania"
from projekty

--task 9
select cast(2 as float) / cast(4 as float)

-- task 10
select distinct(kierownik) from projekty

-- task 11
select 	nazwa,
		placa_min
from stanowiska
order by placa_min desc, nazwa

-- task 12
select 	nazwa,
		datarozp,
		kierownik
from projekty
order by datarozp desc
limit 1

-- task 13
select 	id,
		nazwisko,
		placa,
		stanowisko
from pracownicy
where 	(placa > '2200'::money) and
		((stanowisko = 'adiunkt') 
			or (stanowisko = 'doktorant'))

-- task 14
select nazwa 
from projekty
where nazwa like '%web%'

-- task 15
select nazwisko
from pracownicy
where szef is null

-- task 16
SELECT 	nazwisko, 
		placa,
		dod_funkc,
       	(placa + COALESCE(dod_funkc, '0'::money))
	   		AS "pensja"
FROM  Pracownicy
where (placa + COALESCE(dod_funkc, '0'::money)) > '3500'::money

-- task 17
select 	distinct stanowisko,
		case stanowisko
			when 'profesor'		then 	'badawcze'
			when 'adiunkt'		then 	'badawcze'
			when 'doktorant'	then 	'badawcze'
			else						'administracyjne'
		end as "typ stanowiska"
from pracownicy

select * from pracownicy

-- aditional tasks --

-- task 1
select 'Pracownik nr. ' || cast(id as text) || ' - ' || nazwisko 
	as "informacja"
from pracownicy


-- task 2
select 	nazwisko,
		placa, 
		dod_funkc
from pracownicy
where dod_funkc > (placa / 10) 

-- task 3
select	id,
		nazwa,
		datazakonczfakt
from projekty
where datazakonczfakt is null

-- task 4
select 	id,
		nazwisko,
		coalesce(dod_funkc, '100'::money) as "sdas"
from pracownicy
where stanowisko != 'profesor'

-- task 5
SELECT nazwisko,
       dod_funkc
FROM   Pracownicy
WHERE  dod_funkc > '350'::money
       OR dod_funkc <= '350'::money

-- task 6
SELECT id,
       nazwa,
       dataZakonczFakt,
       CASE
            WHEN dataZakonczFakt is null	THEN 0
            ELSE           					1
       END AS "test CASE"
FROM   Projekty

-- task 7
select 	id,
		nazwisko,
		stanowisko
from pracownicy
order by
	case stanowisko
		when 'profesor' then 1
		when 'adiunkt' then 2
		when 'doktorant' then 3
		else 4
	end,
	stanowisko


-- aditional task 2 --

-- task 1
select klasa, kraj
from klasy
where liczbadzial >= 10

-- task 2
select nazwa as "nazwaOkretu"
from okrety
where zwodowano < 1918

-- task 3
select okret, bitwa
from skutki
where efekt = 'zatopiony'

-- task 4
select nazwa, klasa
from okrety
where nazwa = klasa

-- task 5
select nazwa as "nazwaOkretu"
from okrety
where nazwa like 'R%'

-- task 6
select okret as "nazwaOkretu"
from skutki
where okret like '% % %'

--- task 7
select distinct bitwa
from skutki
where efekt = 'zatopiony'
order by bitwa

-- task 8 
select zwodowano, nazwa
from okrety
order by zwodowano desc
limit 1

-- task 9
select substring(nazwa, 1, 5) as "nazwa5"
from bitwy

-- task 10
SELECT 
    nazwa,
    TO_CHAR(TO_DATE(data, 'MM/DD/YYYY'), 'Mon DD YYYY') AS "data bitwy"
FROM Bitwy;

-- task 11
select 	nazwa,
		extract(year from age(now(),
				TO_DATE(data, 'MM/DD/YYYY')))
				as "ile lat minelo"
from bitwy
where extract(year from age(now(),
				TO_DATE(data, 'MM/DD/YYYY')))
				> 80

SELECT * FROM Klasy;
SELECT * FROM Okrety;
SELECT * FROM Bitwy;
SELECT * FROM Skutki;

-- task 12
select *
from okrety
order by zwodowano desc, nazwa

-- task 13
select 	klasa,
		case typ 
			when	'pn' then 	'pancernik'
			when 	'kr' then 	'krążkownik'
			else 				'nieznany'
		end as "typ"
from klasy
















