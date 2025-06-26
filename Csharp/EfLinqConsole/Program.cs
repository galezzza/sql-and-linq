// See https://aka.ms/new-console-template for more information
using EfLinqConsole.Data;
using EfLinqConsole.Tasks._01___select_base;
using EfLinqConsole.Tasks._02___table_joins;
using EfLinqConsole.Tasks._03___select_subqueries;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5438;Database=mystudydb;Username=admin;Password=admin");

Tasks1 task1 = new Tasks1(optionsBuilder.Options);
Tasks2 task2 = new Tasks2(optionsBuilder.Options);
Tasks3 task3 = new Tasks3(optionsBuilder.Options);

await task1.Execute();