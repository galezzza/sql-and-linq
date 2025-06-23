using EfLinqConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._03___select_subqueries
{
    public class Tasks3(DbContextOptions<MyDbContext> options)
    {
        private readonly DbContextOptions<MyDbContext> options = options;

    }
}
