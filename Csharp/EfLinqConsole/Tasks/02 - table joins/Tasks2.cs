using EfLinqConsole.Data;
using Microsoft.EntityFrameworkCore;

namespace EfLinqConsole.Tasks._02___table_joins
{
    public class Tasks2(DbContextOptions<MyDbContext> options)
    {
        private readonly DbContextOptions<MyDbContext> options = options;

    }
}
