using System.Globalization;
using System.Security.Cryptography;
using EfLinqConsole.Data;
using EfLinqConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._02___table_joins
{
    public class Tasks2
    {
        private readonly DbContextOptions<MyDbContext> options;

        public Tasks2(DbContextOptions<MyDbContext> options)
        {
            this.options = options;
        }

        public async Task Execute()
        {
            await Task1();
            await Task2();
            await Task3();
            await Task4();
            await Task5();
            await Task6();
            await Task7();
            await Task8();
            await Task9();
            await Task10();
            await Task11();
            await AditionalTask1_1();
            await AditionalTask1_2();
            await AditionalTask1_3();
            await AditionalTask1_4();
            await AditionalTask2_1();
            await AditionalTask2_2();
            await AditionalTask2_3();
            await AditionalTask2_4();
            await AditionalTask2_5();
            await AditionalTask2_6();
            await AditionalTask2_7();
            await AditionalTask2_8();
        }

        private async Task Task1()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;

            var stanowiska = context.stanowiskas;

            var result1 = pracownicy
                .SelectMany(p => stanowiska, (p, s) => new { p, s })
                .OrderBy(x => x.p.nazwisko)
                .Select(x => new { x.p.id, x.p.nazwisko, x.p.placa, x.s.nazwa, x.s.placa_min });

            var result2 = pracownicy
                .SelectMany(p => stanowiska, (p, s) => new { p, s })
                .OrderBy(x => x.p.nazwisko)
                .Where(x => x.s.nazwa == "profesor" || x.s.nazwa == "sekretarka")
                .Select(x => new { x.p.id, x.p.nazwisko, x.p.placa, x.s.nazwa, x.s.placa_min });


            Console.WriteLine(nameof(Task1) + "\n");
            foreach (var r in result1)
            {
                PrintRow(15, r.id, r.nazwisko, r.placa, r.nazwa, r.placa_min);
            }
            Console.WriteLine();
        }

        private async Task Task2()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;

            var result = pracownicy.
                Join(stanowiska, p => p.stanowisko, s => s.nazwa, (p, s) => new { p, s })
                .Select(r => new { r.p.nazwisko, r.p.placa, r.s.nazwa, r.s.placa_min, r.s.placa_max });

            Console.WriteLine("\n" + nameof(Task2) + "\n");
            foreach (var r in result)
            {
                PrintRow(20, r.nazwisko, r.placa, r.nazwa, r.placa_min, r.placa_max);
            }
        }

        private async Task Task3()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy
                .Join(realizacje, p => p.id, r => r.idprac, (p, r) => new { p, r })
                .Join(projekty, rp => rp.r.idproj, proj => proj.id, (rp, proj) => new {
                    rp.r, rp.p, proj
                })
                .OrderBy(r => r.p.nazwisko)
                .Select(r => new { r.p.id, r.p.nazwisko, r.proj.nazwa });

            Console.WriteLine("\n" + nameof(Task3) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r.id, r.nazwisko, r.nazwa);
            }
        }

        private async Task Task4()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy
                .Join(stanowiska, p => p.stanowisko, s => s.nazwa, (p, s) => new
                {
                    p.nazwisko,
                    p.placa,
                    p.stanowisko,
                    s.placa_min,
                    s.placa_max
                })
                .Where(r => (r.placa < r.placa_min || r.placa > r.placa_max)
                            && r.stanowisko == "doktorant");


            Console.WriteLine("\n" + nameof(Task2) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r.nazwisko, r.placa, r.stanowisko, r.placa_min, r.placa_max);
            }
        }

        private async Task Task5()
        {

            Console.WriteLine("\n Task 5 not existed for C#\n");

            //await using var context = new MyDbContext(options);

            //var pracownicy = context.pracownicies;
            //var stanowiska = context.stanowiskas;
            //var realizacje = context.realizacjes;
            //var projekty = context.projekties;


            //var result = context.pracownicies;

            //Console.WriteLine("\n" + nameof(Task5) + "\n");
            //foreach (var p in result)
            //{
            //    PrintRow(15, p);
            //}
        }

        private async Task Task6()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = context.pracownicies
                .Join(pracownicy, p1 => p1.nazwisko, p2 => p2.nazwisko, (p1, p2) => new
                {
                    p1.id,
                    p1.nazwisko,
                    id2 = p2.id,
                    nazwisko2 = p2.nazwisko
                })
                .Where(r => r.id > r.id2);

            Console.WriteLine("\n" + nameof(Task6) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task Task7()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;


            var result1 = pracownicy
                .GroupJoin(pracownicy, p1 => p1.szef, p2 => p2.id, (p1, p2) => new
                {
                    p1.nazwisko, p2
                })
                .SelectMany(p1p2 => p1p2.p2.DefaultIfEmpty(),
                (p1p2, p2) => new {
                    p1p2.nazwisko,
                    szef = p2.nazwisko ?? "[null]"
                });

            var result2 = pracownicy.
                GroupJoin(pracownicy, p1 => p1.id, p2 => p2.szef, (p1, p2) => new
                {
                    p1.nazwisko, p1.id, p2
                })
                .SelectMany(p1p2 => p1p2.p2.DefaultIfEmpty(),
                (p1p2, p2) => new {
                    szefId = p1p2.id,
                    szef = p1p2.nazwisko,
                    pracownikId = p2.id,
                    pracownik = p2.nazwisko ?? "[null]"
                })
                .OrderBy(r => r.szefId)
                .ThenBy(r => r.pracownikId)
                .Select(r => new {r.pracownik, r.szef});

            Console.WriteLine("\n" + nameof(Task7) + "\n");
            foreach (var r in result1)
            {
                PrintRow(15, r.nazwisko, r.szef);
            }
            Console.WriteLine();
            foreach (var r in result2)
            {
                PrintRow(15, r.pracownik, r.szef);
            }
        }

        private async Task Task8()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;


            var result = pracownicy
                .GroupJoin(projekty, p => p.id, proj => proj.kierownik, (p, proj) => new
                {
                    p.id,
                    p.nazwisko,
                    proj,
                })
                .SelectMany(p1proj => p1proj.proj.DefaultIfEmpty(), (p1proj, proj) => new
                {
                    p1proj.id,
                    p1proj.nazwisko,
                    proj.kierownik
                })
                .Where(r => r.kierownik == null)
                .OrderBy(r => r.id)
                .Select(r => new { r.id, r.nazwisko });

            Console.WriteLine("\n" + nameof(Task8) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r.id, r.nazwisko);
            }
        }

        private async Task Task9()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy
                .GroupJoin(
                    realizacje.Where(r => r.idproj == 10),
                    p => p.id,
                    r => r.idprac,
                    (p, r) => new
                    {
                        p.id,
                        p.nazwisko,
                        r
                    })
                .SelectMany(
                    pr => pr.r.DefaultIfEmpty(),
                    (pr, r) => new
                    {
                        pr.nazwisko,
                        r.idproj
                    })
                .Where(r => r.idproj == null)
                .Select(r => r.nazwisko);

            Console.WriteLine("\n" + nameof(Task9) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        record ProjectPersonKey(int id, int? kierownik);

        private async Task Task10()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties;
            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;

            var result = realizacje
                .GroupJoin(
                    realizacje
                        .Join(projekty, r => r.idprac, p => p.kierownik, (r1, p1) => new
                        {
                            r1.idproj,
                            r1.idprac,
                            p1.id,
                            p1.nazwa,
                            p1.kierownik
                        }),
                    r2 => r2.idproj,
                    r1p1 => r1p1.idproj,
                    (r2, r1p1) => new
                    {
                        r2.idproj,
                        r2.idprac,
                        r1p1
                    }
                )
                .SelectMany(
                    r1p1r2 => r1p1r2.r1p1.DefaultIfEmpty(),
                    (r1p1r2, r1p1) => new
                    {
                        r1p1r2.idproj,
                        r1p1r2.idprac,
                        id = r1p1 != null ? r1p1.id : (int?)null,
                        nazwa = r1p1 != null ? r1p1.nazwa : null,
                        kierownik = r1p1 != null ? r1p1.kierownik : null
                    })
                .Join(projekty, r1p1r2 => r1p1r2.idproj, p2 => p2.id, (r1p1r2, p2) => new
                {
                    r1p1r2.idproj,
                    maybeNullKierownik = r1p1r2.kierownik,
                    p2.kierownik
                })
                .Where(r1p1r2p2 => r1p1r2p2.maybeNullKierownik == null)
                .Join(
                    pracownicy,
                    r1p1r2p2 => r1p1r2p2.kierownik,
                    pracownic => pracownic.id,
                    (r1p1r2p2, pracownic) => new
                    {
                        pracownic.nazwisko,
                        r1p1r2p2.idproj,
                        r1p1r2p2.maybeNullKierownik
                    });

            Console.WriteLine("\n" + nameof(Task10) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task Task11()
        {
            Console.WriteLine("\n Task 11 not possible in C#\n");
        }

        private async Task AditionalTask1_1()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Select(p => new { p.id, p.nazwisko });

            Console.WriteLine("\n" + nameof(AditionalTask1_1) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, "Pracownik nr. " + p.id + " - " + p.nazwisko);
            }
        }

        private async Task AditionalTask1_2()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Select(p => new { p.nazwisko, p.placa, p.dod_funkc })
                .ToList()
                .Where(p => p.placa < 10 * (p.dod_funkc ?? 0));

            Console.WriteLine("\n" + nameof(AditionalTask1_2) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p.nazwisko, p.placa, p.dod_funkc);
            }
        }

        private async Task AditionalTask1_3()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties
                .Where(p => p.datazakonczfakt == null)
                .Select(p => new { p.id, p.nazwa, p.datazakonczfakt });

            Console.WriteLine("\n" + nameof(AditionalTask1_3) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(15, p.id, p.nazwa, p.datazakonczfakt == null ? "[null]" : p.datazakonczfakt.ToString());
            }
        }

        private async Task AditionalTask1_4()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Where(p => p.stanowisko.Equals("profesor") != true)
                .Select(p => new { p.id, p.nazwisko, premia = p.dod_funkc ?? 100 });

            Console.WriteLine("\n" + nameof(AditionalTask1_4) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p);
            }
        }
        
        private async Task AditionalTask2_1()
        {
            await using var context = new MyDbContext(options);

            var klasy = context.klasies
                .Where(k => k.liczbadzial >= 10)
                .Select(k => new { k.klasa, k.kraj });

            Console.WriteLine("\n" + nameof(AditionalTask2_1) + "\n");
            foreach (var k in klasy)
            {
                PrintRow(15, k);
            }
        }
        
        private async Task AditionalTask2_2()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties
                .Where(o => o.zwodowano == null || o.zwodowano < 1918)
                .Select(o => o.nazwa);

            Console.WriteLine("\n" + nameof(AditionalTask2_2) + "\n");
            foreach (var o in okrety)
            {
                PrintRow(15, o);
            }
        }

        private async Task AditionalTask2_3()
        {
            await using var context = new MyDbContext(options);

            var skutki = context.skutkis
                .Where(s => s.efekt == "zatopiony")
                .Select(s => new { s.okret, s.bitwa });

            Console.WriteLine("\n" + nameof(AditionalTask2_3) + "\n");
            foreach (var s in skutki)
            {
                PrintRow(15, s);
            }
        }

        private async Task AditionalTask2_4()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties
                .Where(o => o.klasa == o.nazwa)
                .Select(o => o.nazwa);

            Console.WriteLine("\n" + nameof(AditionalTask2_4) + "\n");
            foreach (var o in okrety)
            {
                PrintRow(15, o);
            }
        }

        private async Task AditionalTask2_5()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties
                .Where(o => o.nazwa.StartsWith("R"))
                .Select(o => o.nazwa);

            var skutki = context.skutkis
                .Where(s => s.okret.StartsWith("R"))
                .Select(s => s.okret);

            var result = okrety.Concat(skutki);

            Console.WriteLine("\n" + nameof(AditionalTask2_5) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_6()
        {
            await using var context = new MyDbContext(options);

            var skutki = context.skutkis
                .Select(s => s.okret)
                .AsEnumerable()
                .Where(s => s.Count(c => c == ' ') >= 2);

            Console.WriteLine("\n" + nameof(AditionalTask2_6) + "\n");
            foreach (var s in skutki)
            {
                PrintRow(15, s);
            }
        }

        private async Task AditionalTask2_7()
        {
            await using var context = new MyDbContext(options);

            var skutki = context.skutkis
                .Where(s => s.efekt == "zatopiony")
                .Select(s => s.bitwa)
                .Distinct();

            Console.WriteLine("\n" + nameof(AditionalTask2_7) + "\n");
            foreach (var s in skutki)
            {
                PrintRow(15, s);
            }
        }
        
        private async Task AditionalTask2_8()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties
                .OrderByDescending(o => o.zwodowano)
                .Select(o => new { o.zwodowano, o.nazwa })
                .Take(1);

            Console.WriteLine("\n" + nameof(AditionalTask2_8) + "\n");
            foreach (var o in okrety)
            {
                PrintRow(15, o);
            }
        }

        void PrintRow(int columnWidth, params object[] values)
        {
            string format = string.Join("  ", Enumerable.Range(0, values.Length)
                .Select(i => $"{{{i},-{columnWidth}}}"));
            Console.WriteLine(string.Format(format, values));
        }
    }
}
