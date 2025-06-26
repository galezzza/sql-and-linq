using System.Data;
using System.Globalization;
using System.Numerics;
using System.Threading.Tasks.Dataflow;
using EfLinqConsole.Data;
using EfLinqConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._01___select_base
{
    public class Tasks1
    {
        private readonly DbContextOptions<MyDbContext> options;

        public Tasks1(DbContextOptions<MyDbContext> options)
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
            await Task12();
            await Task13();
            await Task14();
            await Task15();
            await Task16();
            await Task17();
            await Task17();
            await AditionalTask1_1();
            await AditionalTask1_2();
            await AditionalTask1_3();
            await AditionalTask1_4();
            await AditionalTask1_5();
            await AditionalTask1_6();
            await AditionalTask1_7();
            await AditionalTask2_1();
            await AditionalTask2_2();
            await AditionalTask2_3();
            await AditionalTask2_4();
            await AditionalTask2_5();
            await AditionalTask2_6();
            await AditionalTask2_7();
            await AditionalTask2_8();
            await AditionalTask2_9();
            await AditionalTask2_10();
            await AditionalTask2_11();
            await AditionalTask2_12();
            await AditionalTask2_13();
        }

        private async Task Task1()
        {
            await using var context = new MyDbContext(options);

            var projekty = await context.projekties
                .Select(p => new { p.id, p.nazwa, p.stawka })
                .ToListAsync();

            Console.WriteLine(nameof(Task1) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(20, p.id, p.nazwa, p.stawka);
            }
            Console.WriteLine();
        }


        private async Task Task2()
        {
            await using var context = new MyDbContext(options);
            
            var props = typeof(projekty).GetProperties()
                .Where(p => !(p.GetMethod?.IsVirtual ?? false));
            var pracownicy = await context.projekties.ToListAsync();

            Console.WriteLine("\n" + nameof(Task2) + "\n");
            PrintRow(20, props.Select(p => (object)p.Name).ToArray());
            foreach (var p in pracownicy)
            {
                PrintRow(20, props.Select(prop => prop.GetValue(p) ?? "[null]").ToArray());
            }
        }

        private async Task Task3()
        {
            Console.WriteLine("\n Task 3 not existed for C#\n");
        }

        private async Task Task4()
        {
            Console.WriteLine("\n Task 4 not existed for C#\n");
        }

        private async Task Task5()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies.Select(p => new { p.nazwisko, p.placa });

            Console.WriteLine("\n" + nameof(Task5) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p.nazwisko, p.placa * 12);
            }
        }

        private async Task Task6()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies.Select(p => new { p.nazwisko, p.zatrudniony });

            Console.WriteLine("\n" + nameof(Task6) + "\n");
            foreach (var p in pracownicy)
            {
                var now = DateTime.Now;
                DateTime zatr = p.zatrudniony ?? DateTime.Now;

                int monthCount = (now.Year - zatr.Year) * 12 + now.Month - zatr.Month;

                PrintRow(15, p.nazwisko, monthCount);
            }
        }

        private async Task Task7()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies.Select(p => new { p.nazwisko, p.placa, p.dod_funkc });

            Console.WriteLine("\n" + nameof(Task7) + "\n");
            foreach (var p in pracownicy)
            {
                var roczne = (p.placa + (p.dod_funkc ?? 0)) * 12;
                PrintRow(15, p.nazwisko, roczne);
            }
        }

        private async Task Task8()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties.Select(p => new {p.nazwa, p.datarozp ,p.datazakonczfakt});

            Console.WriteLine("\n" + nameof(Task8) + "\n");
            foreach (var p in projekty)
            {
                int czasTrwania = (p.datazakonczfakt ?? DateTime.Now).Subtract(p.datarozp).Days;
                PrintRow(15, p.nazwa, czasTrwania);
            }
        }

        private async Task Task9()
        {
            Console.WriteLine("\n" + nameof(Task9) + "\n");
            Console.WriteLine((float)2 / (float)4);
        }

        private async Task Task10()
        {
            await using var context = new MyDbContext(options);

            var projekty = await context.projekties.Select(p => p.kierownik).Distinct().ToListAsync();

            Console.WriteLine("\n" + nameof(Task10) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(15, p);
            }
        }

        private async Task Task11()
        {
            await using var context = new MyDbContext(options);

            var stanowiska = await context.stanowiskas
                .Select(s => new { s.nazwa, s.placa_min })
                .OrderByDescending(s => s.placa_min)
                .ThenByDescending(s => s.nazwa)
                .ToListAsync();

            Console.WriteLine("\n" + nameof(Task11) + "\n");
            foreach (var s in stanowiska)
            {
                PrintRow(15, s.nazwa, s.placa_min);
            }
        }

        private async Task Task12()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties
                .OrderByDescending(p => p.datarozp)
                .Take(1)
                .Select(p => new { p.nazwa, p.datarozp, p.kierownik } )
                .ToList();

            Console.WriteLine("\n" + nameof(Task12) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(15, p.nazwa, p.datarozp, p.kierownik);
            }
        }

        private async Task Task13()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Where(p => p.stanowisko == "adiunkt" || p.stanowisko == "doktorant")
                .Where(p => p.placa > 2200)
                .Select(p => new { p.id, p.nazwisko, p.placa, p.stanowisko });
                

            Console.WriteLine("\n" + nameof(Task13) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p);
            }
        }
        
        private async Task Task14()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties
                .Where(p => p.nazwa.Contains("web"))
                .Select(p => p.nazwa);

            Console.WriteLine("\n" + nameof(Task14) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(15, p);
            }
        }
        
        private async Task Task15()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Where(p => p.szef == null)
                .Select(p => p.nazwisko);

            Console.WriteLine("\n" + nameof(Task15) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p);
            }
        }
        
        private async Task Task16()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Select(p => new { p.id, p.nazwisko, p.placa, p.dod_funkc, pensja = p.placa + (p.dod_funkc ?? 0) });

            Console.WriteLine("\n" + nameof(Task16) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p.id, p.nazwisko, p.placa, p.dod_funkc == null ? "[null]" : p.dod_funkc.ToString(), p.pensja);
            }
        }
        private async Task Task17()
        {
            await using var context = new MyDbContext(options);

            var stanowiska = context.stanowiskas
                .OrderBy(s => s.nazwa)
                .Select(s => new { s.nazwa });

            Console.WriteLine("\n" + nameof(Task17) + "\n");
            foreach (var s in stanowiska)
            {
                var type = s.nazwa switch
                {
                    "profesor" => "badawcze",
                    "adiunkt" => "badawcze",
                    "doktorant" => "badawcze",
                    _ => "administracyjne"
                };
                PrintRow(15, s.nazwa, type);
            }
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
                .Select(p => new { p.id, p.nazwisko, premia = p.dod_funkc ?? 100});

            Console.WriteLine("\n" + nameof(AditionalTask1_4) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p);
            }
        }

        private async Task AditionalTask1_5()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies
                .Where(p => p.dod_funkc > 350 || p.dod_funkc <= 350)
                .Select(p => new { p.nazwisko, p.dod_funkc });

            Console.WriteLine("\n" + nameof(AditionalTask1_5) + "\n");
            foreach (var p in pracownicy)
            {
                PrintRow(15, p);
            }
        }

        private async Task AditionalTask1_6()
        {
            await using var context = new MyDbContext(options);

            var projekty = context.projekties
                .Select(p => new { p.id, p.nazwa, p.datazakonczfakt });

            Console.WriteLine("\n" + nameof(AditionalTask1_6) + "\n");
            foreach (var p in projekty)
            {
                PrintRow(20, 
                    p.id,
                    p.nazwa,
                    p.datazakonczfakt == null ? "[null]" : p.datazakonczfakt.ToString(),
                    p.datazakonczfakt == null ? 0 : 1);
            }
        }

        class StanowiskoComparer : IComparer<string>
        {
            private static readonly Dictionary<string, int> _priority = new(StringComparer.OrdinalIgnoreCase)
            {
                ["profesor"] = 0,
                ["adiunkt"] = 1,
                ["doktorant"] = 2
            };

            public int Compare(string? x, string? y)
            {
                int px = _priority.ContainsKey(x ?? "") ? _priority[x ?? ""] : 3;
                int py = _priority.ContainsKey(y ?? "") ? _priority[y ?? ""] : 3;

                return px != py ? px.CompareTo(py) : string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }


        private async Task AditionalTask1_7()
        {
            await using var context = new MyDbContext(options);

            var comparer = new StanowiskoComparer();

            var pracownicy = context.pracownicies
                .Select(p => new { p.id, p.nazwisko, p.stanowisko})
                .AsEnumerable()
                .OrderBy(p => p.stanowisko, comparer);

            Console.WriteLine("\n" + nameof(AditionalTask1_7) + "\n");
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
        private async Task AditionalTask2_9()
        {
            await using var context = new MyDbContext(options);

            var bitwy = context.bitwies
                .Select(b => b.nazwa);

            Console.WriteLine("\n" + nameof(AditionalTask2_9) + "\n");
            foreach (var b in bitwy)
            {
                PrintRow(15, b[..5]);
            }
        }
        private async Task AditionalTask2_10()
        {
            await using var context = new MyDbContext(options);

            var bitwy = context.bitwies
                .Select(b => new
                {
                    b.nazwa,
                    data_bitwy = DateTime.ParseExact(
                        b.data,
                        "M/d/yyyy",
                        CultureInfo.InvariantCulture
                    ).ToString("MMM dd yyyy", CultureInfo.InvariantCulture)
                });

            Console.WriteLine("\n" + nameof(AditionalTask2_10) + "\n");
            foreach (var b in bitwy)
            {
                PrintRow(15, b.nazwa, b.data_bitwy);
            }
        }

        private async Task AditionalTask2_11()
        {
            await using var context = new MyDbContext(options);

            var bitwy = context.bitwies
                .Select(b => new {
                    b.nazwa,
                    ileLatMinelo = DateTime.UtcNow.Year - 1 -
                    DateTime.ParseExact(b.data, "M/d/yyyy", CultureInfo.InvariantCulture).Year
                })
                .AsEnumerable()
                .Where(b => b.ileLatMinelo > 80);

            Console.WriteLine("\n" + nameof(AditionalTask2_11) + "\n");
            foreach (var b in bitwy)
            {
                PrintRow(15, b.nazwa, b.ileLatMinelo);
            }
        }

        private async Task AditionalTask2_12()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties
                .OrderByDescending(o => o.zwodowano)
                .ThenBy(o => o.nazwa)
                .Select(o => new { o.nazwa, o.klasa, o.zwodowano });

            Console.WriteLine("\n" + nameof(AditionalTask2_12) + "\n");
            foreach (var o in okrety)
            {
                PrintRow(15, o.nazwa, o.klasa, o.zwodowano);
            }
        }

        private async Task AditionalTask2_13()
        {
            await using var context = new MyDbContext(options);

            var klasy = context.klasies
                .Select(k => new { k.klasa, k.typ });

            Console.WriteLine("\n" + nameof(AditionalTask2_13) + "\n");
            foreach (var k in klasy)
            {
                string type = k.typ switch
                {
                    "pn" => "pancernik",
                    "kr" => "krążownik",
                    _ => "nieznany"
                };
                PrintRow(15, k.klasa, type);
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
