
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


















