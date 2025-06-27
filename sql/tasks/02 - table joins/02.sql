 
-- task 1
select 	id,
		nazwisko,
		placa,
		nazwa,
		placa_min
from pracownicy
	cross join stanowiska
order by nazwisko, nazwa;

select 	id,
		nazwisko,
		placa,
		nazwa,
		placa_min
from pracownicy
	cross join stanowiska
where nazwa = 'profesor' or nazwa = 'sekretarka'
order by nazwisko, nazwa

-- task 2

select 	P.nazwisko,
		P.placa,
		P.stanowisko,
		S.placa_min,
		S.placa_max
from pracownicy P
	inner join stanowiska S
		on P.stanowisko = S.nazwa 

-- task 3

select 	R.idprac,
		P.nazwisko,
		Proj.nazwa
from realizacje R
	inner join pracownicy P
		on R.idprac = P.id
	inner join projekty Proj
		on R.idproj = Proj.id
order by nazwisko


-- task 4

select 	P.nazwisko,
		P.placa,
		P.stanowisko,
		S.placa_min,
		S.placa_max
from pracownicy P
	inner join stanowiska S
		on P.stanowisko = S.nazwa 
where stanowisko = 'doktorant' and
		placa > placa_min and placa < placa_max


-- task 6

select 	P1.id,
		P1.nazwisko,
		P2.id,
		P2.nazwisko
from pracownicy P1
	inner join pracownicy P2
		on P1.nazwisko = P2.nazwisko
		 and P1.id != P2.id
		 and P1.id < P2.id

-- task 7 - a

select	P1.nazwisko,
		P2.nazwisko
from pracownicy P1
	left join pracownicy P2
		on P1.szef = P2.id

-- task 7 - b

select	P2.nazwisko as "pracownik",
		P1.nazwisko as "szef"
from pracownicy P1
	left join pracownicy P2
		on P2.szef = P1.id
order by P1.id


-- task 8

select 	P.id,
		P.nazwisko
from pracownicy P
	left join projekty Proj
		on Proj.kierownik = P.id
where Proj.id is null
order by P.id

-- task 9

select P.nazwisko
from pracownicy P
	left join realizacje R
		on P.id = R.idprac
		and R.idproj = 10
where idproj is null

-- task 10

select 	R.idprac,
		Proj.id,
		Proj.kierownik,
		P.nazwisko
from realizacje R
	right join projekty Proj
		on Proj.id = R.idproj
			and Proj.kierownik = R.idprac
	inner join pracownicy P
		on Proj.kierownik = P.id
where R.idprac is null

select distinct R1.idproj, R1.idprac,
				R2.idproj,
				Proj2.nazwa, Proj2.kierownik,
				P.nazwisko
from realizacje R1
	inner join projekty Proj1
		on Proj1.kierownik = R1.idprac	
	right join realizacje R2
		on R1.idproj = R2.idproj
	inner join projekty Proj2
		on Proj2.id = R2.idproj
	inner join pracownicy P
		on P.id = Proj2.kierownik
where Proj1.id = R1.idproj or R1.idproj is null 

select *
from realizacje R1
	left join (select idproj, idprac, id, nazwa, kierownik
				from realizacje R2
					inner join projekty Proj1
						on Proj1.kierownik = R2.idprac) R2Proj1
		on R1.idproj = R2Proj1.


select  		R1.idproj, R1.idprac,
				Proj2.kierownik,
				Proj1.kierownik, Proj1.id
FROM realizacje R1
	LEFT JOIN projekty Proj1
    	ON Proj1.kierownik = R1.idprac
	inner JOIN projekty Proj2
    	ON Proj2.id = R1.idproj
order by R1.idproj
		
where Proj1.id is null or Proj1.id != R1.idproj
	
  inner JOIN realizacje R2
    ON R1.idproj = R2.idproj
  


-- task 11

select P1.nazwisko, P1.placa
from pracownicy P1
	left join pracownicy P2
		on P1.placa < P2.placa
where P2.id is null 	


-- aditional tasks 1

-- task 1

select proj.nazwa
from projekty Proj
	right join pracownicy P
		on Proj.kierownik = P.id
where P.nazwisko = 'Mielcarz'


-- task 2

select Proj.nazwa
from realizacje R
	right join pracownicy P
		on R.idprac = P.id
	inner join projekty Proj
		on Proj.id = R.idproj
where P.nazwisko = 'Andrzejewicz'


-- task 3

select 	P1.nazwisko,
		P1.placa,
		P2.placa
from pracownicy P1
	inner join pracownicy P2
		on P1.placa > P2.placa
			and P2.nazwisko = 'Różycka'

-- task 4

select Proj.nazwa
from realizacje R
	right join pracownicy P
		on R.idprac = P.id
			and P.stanowisko = 'doktorant' 
	right join projekty Proj
		on R.idproj = Proj.id
where R.idproj is null


-- aditional tasks 2


-- task 1 

select O.nazwa
from okrety O
	inner join klasy K
		on O.klasa = K.klasa
where K.wypornosc > 35000


-- task 2

select 	O.nazwa, K.wypornosc, K.liczbadzial
from okrety O
	inner join skutki S
		on S.okret = O.nazwa
	inner join klasy K
		on O.klasa = K.klasa
where bitwa = 'Guadalcanal'

-- task 3

select K2.kraj
from klasy K1
	full join klasy K2
		on K1.kraj = K2.kraj
where K1.typ = 'pn' and K2.typ = 'kr'

-- task 4

select K.*, O.* from okrety O
left join klasy K
	on O.klasa = K.klasa

-- task 5

select S.okret, K.wypornosc, K.liczbadzial 
from okrety O
	right join skutki S
		on S.okret = O.nazwa
	left join klasy K
		on O.klasa = K.klasa
where bitwa = 'Guadalcanal'

-- task 6

select K.klasa
from klasy K
	left join okrety O
		on O.klasa = K.klasa
where O.nazwa is null


-- task 7

select K2.kraj
from klasy K1
	right join klasy K2 
		on K1.liczbadzial > K2.liczbadzial
where K1.liczbadzial is null

-- task 8

select * from okrety;
select * from bitwy;
select * from skutki;
select * from klasy;


select distinct K1.kaliber,
		coalesce(K2.klasa, K1.klasa) as "klasa",
		O.nazwa
from klasy K1
	left join klasy K2
		on K1.kaliber = K2.kaliber
			and K1.liczbadzial < K2.liczbadzial
	inner join okrety O
		on coalesce(K2.klasa, K1.klasa) = O.klasa
order by klasa














