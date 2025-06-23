
-- task 1
select nazwisko
from pracownicy
where placa > 	(select placa
				from pracownicy
				where nazwisko = 'Różycka')



-- task 2
select nazwisko
from pracownicy
where id not in	(select kierownik
				from projekty)


-- task 3
select nazwisko
from pracownicy
where id not in (select idprac
				from realizacje
				where idproj = 10)


-- task 4

select nazwisko
from pracownicy
where id in	(select idprac
			from realizacje
			where idproj = 	(select id
							from projekty
							where nazwa = 'e-learning'))

-- task 5
select nazwisko, placa
from pracownicy
where placa >= all (select placa
					from pracownicy)

-- task 6

select 	Proj.id,
		Proj.nazwa,
		Proj.stawka,
		Proj.stawka * 40 as "tygodniowka",
		Proj.kierownik,
		P.placa
from projekty Proj
	inner join pracownicy P
		on Proj.kierownik = P.id

select nazwa
from projekty Proj
where (stawka * 40) > 	(select placa
						from pracownicy P
						where P.id = Proj.kierownik)

-- task 7
select nazwisko, id
from pracownicy P1
where P1.nazwisko in (select nazwisko 
					from pracownicy P2
					where 	P1.nazwisko = P2.nazwisko
							and P1.id != P2.id)


-- task 8

select nazwisko
from pracownicy P
where P.szef in (select idprac
				from realizacje R1
				where R1.idproj in	(select idproj
									from realizacje R2
									where R2.idprac = P.id))
order by nazwisko

-- task 9

select distinct	P.nazwisko
from realizacje R
	left join pracownicy P
		on R.idprac = P.id
	left join realizacje R2
		on P.szef = R2.idprac
where R.idproj = R2.idproj
order by nazwisko


-- task 10
select nazwisko
from pracownicy
where id not in 	(select kierownik
					from projekty)


select nazwisko
from pracownicy P
where not exists 	(select kierownik
					from projekty Proj
					where P.id = Proj.kierownik)

-- task 11
SELECT id,
       nazwisko
FROM   Pracownicy
WHERE  id NOT IN (SELECT szef
                  FROM   Pracownicy);

SELECT id,
       nazwisko
FROM   Pracownicy P1
WHERE  NOT EXISTS (SELECT 1
                   FROM   Pracownicy P2
                   WHERE  P2.szef = P1.id);

-- task 12

select nazwisko
from pracownicy P
where not exists (select *
				from projekty Proj
				where Proj.id not in (select idproj
									from realizacje R
									where R.idprac = P.id))


-- aditional tasks 1

-- task 1
select nazwisko
from pracownicy P
where P.id in	(select kierownik
				from projekty
				where nazwa = 'neural network')

-- task 2
select nazwa
from projekty
where kierownik in (select id
					from pracownicy
					where nazwisko = 'Mielcarz')

-- task 3
select nazwisko
from pracownicy P1
where not exists (select 1
				from pracownicy P2
				where P1.id = P2.szef)

-- task 4 - a
select 	stanowisko,
		nazwisko
from pracownicy P1
where placa >= all 	(select placa
					from pracownicy P2
					where P1.stanowisko = P2.stanowisko)

-- task 4 - b
select 	stanowisko,
		nazwisko
from pracownicy P1
where not exists 	(select *
					from pracownicy P2
					where P2.placa > P1.placa
					and P1.stanowisko = P2.stanowisko)

-- aditional tasks 2

-- task 1
select kraj 
from klasy K1
where liczbadzial >= all (select liczbadzial
						from klasy K2)

-- task 2
select klasa
from klasy
where klasa = any (select klasa
				from okrety
				where nazwa in (select okret
							from skutki
							where efekt = 'zatopiony'))

-- task 3
select nazwa
from okrety
where klasa in (select klasa
				from klasy
				where kaliber = 16)

-- task 4
select nazwa 
from bitwy
where nazwa in (select bitwa
				from skutki 
				where okret in (select nazwa
							from okrety
							where klasa = 'Kongo'))

-- task 5
select * from okrety;
select * from skutki;
select * from bitwy;
select * from klasy;

select K1.kaliber, O.nazwa, K1.liczbadzial
from klasy K1
	inner join okrety O
		on K1.klasa = O.klasa 
where liczbadzial >= all (select liczbadzial
						from klasy K2
						where K1.kaliber = K2.kaliber)
order by K1.kaliber







































