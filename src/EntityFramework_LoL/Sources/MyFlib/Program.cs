// See https://aka.ms/new-console-template for more information
using MyFlib;
using static System.Console;

using (var context = new LolDbContext())
{

    foreach (var c in context.Champions)
    {
        WriteLine($"{c.Name} - {c.Class}");
    }

    WriteLine("\nWith new Champions :\n");

    DataSeeder.SeedData(context);
    foreach (var c in context.Champions)
    {
        WriteLine($"{c.Name} - {c.Class}");
        foreach (var s in c.Skills)
        {
            WriteLine($"\t\t{s.Name} - {s.Description}");
        }
    }

    context.SaveChangesAsync(); // or context.SaveChangesAsync
}