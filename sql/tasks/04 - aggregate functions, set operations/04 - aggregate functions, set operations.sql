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
		cast(placa as numeric) * 100 / (select AVG(placa::numeric) from pracownicy)
from pracownicy



-- aditional tasks

-- task 1

select nazwisko, placa
from pracownicy P1
where 3::bigint > (select count(nazwisko)
			from pracownicy P2
			where P1.placa < P2.placa)

-- task 2

select 	P.id,
		nazwisko,
		sum(godzin) *
		sum(stawka) *
		EXTRACT(
			EPOCH FROM sum(datazakonczplan - datarozp)
			) / (7 * 24 * 60 * 60) as godzin
from pracownicy P
	right join realizacje R
		on R.idprac = P.id
	inner join projekty Proj
		on R.idproj = Proj.id
group by P.id
order by godzin desc


-- task 3

select *
from 	(select nazwisko,
				count(idprac) as liczba_projektow
		from pracownicy P
			left join realizacje R
				on R.idprac = P.id
		group by nazwisko)
where liczba_projektow = (select max(liczba_projektow)
						from (select nazwisko,
									count(idprac) as liczba_projektow
							from pracownicy P
								left join realizacje R
									on R.idprac = P.id
							group by nazwisko))

-- aditional task 1

-- task 1
select nazwisko, placa
from pracownicy P1
where 3 >= (select count(*)
			from pracownicy P2
			where placa > P1.placa)

-- task 2

select 	nazwisko,
		sum(
			Proj.stawka *
			R.godzin *
			EXTRACT(EPOCH FROM (Proj.datazakonczplan - Proj.datarozp))
				/ (7 * 24 * 60 * 60)
		)as zarobki
from pracownicy P
inner join realizacje R
	on P.id = R.idprac
inner join projekty Proj
	on Proj.id = R.idproj
group by nazwisko
order by zarobki desc


-- task 3

select nazwisko,
		count(idprac) as aaa
from pracownicy P
inner join realizacje R
	on P.id = R.idprac
group by nazwisko
having count(idprac) >= all (select count(R1.idprac)
						from pracownicy P1
						inner join realizacje R1
							on P1.id = R1.idprac
						group by nazwisko)

-- additional tasks 2

-- task 1

select count(typ)
from klasy
where typ = 'pn'

-- task 2
select 	klasa,
		Min(zwodowano)
from okrety
group by klasa
order by klasa

-- task 3

select 	coalesce(K.klasa, 'nieznany') as klasa,
		count(case when S.efekt = 'zatopiony' then 1 end) as zatopionych
from klasy K
	left join okrety O
		on O.klasa = K.klasa
	full join skutki S
		on S.okret = O.nazwa
group by K.klasa
order by K.klasa

-- task 4

select 	coalesce(K.klasa, 'nieznany') as klasaa,
		count(coalesce(O.nazwa, S.okret)) as "liczba okretow",
		count(case when S.efekt = 'zatopiony' then 1 end) as zatopionych
		-- S.efekt
from klasy K
	left join okrety O
		on O.klasa = K.klasa
	full join skutki S
		on S.okret = O.nazwa
where K.klasa is not null
group by K.klasa
having 	count(coalesce(O.nazwa, S.okret)) > 3 and
		count(case when S.efekt = 'zatopiony' then 1 end) > 0

-- task 5

select 	K.kraj,
		avg(K.kaliber^3/2)
from klasy K
	join okrety O
		on O.klasa = K.klasa
where kraj != 'Niemcy'
group by kraj
order by kraj

-- task 6

select 	kraj
from klasy
where liczbadzial = (select max(liczbadzial)from klasy)

-- task 7

select nazwa, liczbadzial
from okrety O
	left join klasy K1
		on K1.klasa = O.klasa
where liczbadzial in (select max(liczbadzial)
					from klasy K2
					where kaliber = K1.kaliber
					group by kaliber)
order by liczbadzial desc, nazwa

-- task 8

select nazwa as nazwa_okretu
from klasy K
	inner join okrety O
		on O.klasa = K.klasa
where typ = 'pn'

UNION 

select okret as nazwa_okretu
from skutki

order by nazwa_okretu;

-- task 9
select 	klasa,
		count(klasa) as ilosc
from okrety
group by klasa
having count(klasa) = 4

-- task 10

select kraj
from klasy
group by kraj
having count(distinct typ) >1






