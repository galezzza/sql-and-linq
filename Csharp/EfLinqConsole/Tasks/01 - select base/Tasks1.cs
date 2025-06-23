using EfLinqConsole.Data;
using EfLinqConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._01___select_base
{
    public class Tasks1(DbContextOptions<MyDbContext> options)
    {
        private readonly DbContextOptions<MyDbContext> options = options;


        public void Execute()
        {
            Task1();
        }

        private void Task1()
        {
            using var context = new MyDbContext(options);

            var projekty = (
                from p in context.projekties
                select new { p.id, p.nazwa, p.stawka }
            );

            foreach (var p in projekty)
            {
                PrintRow(20, p.id, p.nazwa, p.stawka);
            }

        }

        void PrintRow(int columnWidth, params object[] values)
        {
            string format = string.Join("  ", Enumerable.Range(0, values.Length)
                .Select(i => $"{{{i},-{columnWidth}}}"));
            Console.WriteLine(string.Format(format, values));


            //int columnWidth = 30;
            //foreach (var p in projekty)
            //{
            //    Console.WriteLine(string.Format(
            //        "{0,-" + columnWidth + "}" +
            //        "  {1,-" + columnWidth + "}" +
            //        "  {2,-" + columnWidth + "}",
            //    p.id, p.nazwa, p.stawka));
            //}
        }

    }
}
