-- task 1

select 	AVG(P.placa::numeric) as "średnia",
		Count(*) as "liczba" 
from pracownicy P
	inner join Realizacje R
		on P.id = R.idprac
	inner join Projekty Proj
		on Proj.id = R.idproj
where Proj.nazwa = 'e-learning';


-- task 2
select	nazwisko, placa
from Pracownicy
where placa = 	(select Max(placa)
				from pracownicy);


-- task 3
select stanowisko, nazwisko, placa
from pracownicy P1
where placa >= (select Max(placa)
				from pracownicy P2
				where P2.stanowisko = P1.stanowisko);


-- task 4
select Count(distinct idprac) as "ilu różnych pracowników"
from realizacje;


-- task 5
SELECT count(distinct szef) AS "liczba szefów"
FROM   Pracownicy;


-- task 6
select szef, Min(placa), Max(placa)
from pracownicy
where szef is not null
group by szef
order by szef


-- task 7
select 	P1.nazwisko,
		count(P2.nazwisko)
from pracownicy P1
	left join Pracownicy P2
		on P1.id = P2.szef 
group by P1.nazwisko
order by P1.nazwisko


-- task 8

select 	nazwisko,
		Count(distinct R.idproj)
from pracownicy P
	right join realizacje R
		on P.id = R.idprac
where 	P.stanowisko != 'profesor'
group by nazwisko
having Count(distinct R.idproj) > 1


-- task 9
select 	nazwisko,
		count(nazwisko) as "liczba"
from pracownicy
group by nazwisko
having count(nazwisko) > 1


-- task 10

select	nazwa,
		datazakonczplan as DataZakonczenia,
		'projekt trwa' as status 
from projekty
where datazakonczfakt is null

Union all

select	nazwa,
		datazakonczfakt as DataZakonczenia,
		'projekt trwa' as status 
from projekty
where datazakonczfakt is not null


-- task 11

select P.id, P.nazwisko
from pracownicy P
	left join projekty Proj
		on P.id = Proj.kierownik

EXCEPT

select P.id, P.nazwisko
from pracownicy P
	left join projekty Proj
		on P.id = Proj.kierownik
where Proj.kierownik is not null
order by id


-- task 12
select *
from 	(select id,
			nazwisko,
			placa,
			dod_funkc,
			placa + coalesce(dod_funkc, 0::money) as aa
		from pracownicy)
where aa > 3000::money


-- task 13

select 	id,
		nazwisko,
		placa
from pracownicy


select *
from stanowiska

























