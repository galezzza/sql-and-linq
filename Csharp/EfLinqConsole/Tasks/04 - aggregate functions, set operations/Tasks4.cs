using EfLinqConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._03___select_subqueries
{
    public class Tasks4
    {
        private readonly DbContextOptions<MyDbContext> options;

        public Tasks4(DbContextOptions<MyDbContext> options)
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
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

            Console.WriteLine(nameof(Task1) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
            Console.WriteLine();
        }

        private async Task Task2()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

            Console.WriteLine("\n" + nameof(Task2) + "\n");
            foreach (var r in result)
            {
                PrintRow(20, r);
            }
        }

        private async Task Task3()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

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

            var result = pracownicy;


            Console.WriteLine("\n" + nameof(Task2) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task Task5()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;


            var result = context.pracownicies;

            Console.WriteLine("\n" + nameof(Task5) + "\n");
            foreach (var p in result)
            {
                PrintRow(15, p);
            }
        }

        private async Task Task6()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

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

            var result = pracownicy;

            Console.WriteLine("\n" + nameof(Task7) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task Task8()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

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

            var result = pracownicy;

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

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

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

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

            Console.WriteLine("\n" + nameof(AditionalTask1_1) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask1_2()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

            Console.WriteLine("\n" + nameof(AditionalTask1_2) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask1_3()
        {
            Console.WriteLine("\n AditionalTask1_3 not possible in C#\n");
        }

        private async Task AditionalTask1_4()
        {
            await using var context = new MyDbContext(options);

            var pracownicy = context.pracownicies;
            var stanowiska = context.stanowiskas;
            var realizacje = context.realizacjes;
            var projekty = context.projekties;

            var result = pracownicy;

            Console.WriteLine("\n" + nameof(AditionalTask1_4) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_1()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_1) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_2()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_2) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_3()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_3) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_4()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_4) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_5()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_5) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_6()
        {
            await using var context = new MyDbContext(options);

            var okrety = context.okreties;
            var bitwy = context.bitwies;
            var skutki = context.skutkis;
            var klasy = context.klasies;

            var result = klasy;

            Console.WriteLine("\n" + nameof(AditionalTask2_6) + "\n");
            foreach (var r in result)
            {
                PrintRow(15, r);
            }
        }

        private async Task AditionalTask2_7()
        {
            Console.WriteLine("\n AditionalTask2_7 not possible in C#\n");
        }

        private async Task AditionalTask2_8()
        {
            Console.WriteLine("\n AditionalTask2_8 not possible in C#\n");
        }

        void PrintRow(int columnWidth, params object[] values)
        {
            string format = string.Join("  ", Enumerable.Range(0, values.Length)
                .Select(i => $"{{{i},-{columnWidth}}}"));
            Console.WriteLine(string.Format(format, values));
        }
    }
}
