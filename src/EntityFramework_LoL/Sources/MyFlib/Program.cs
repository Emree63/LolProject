// See https://aka.ms/new-console-template for more information
using MyFlib;

using (var context = new LolDbContext())
{

    foreach (var c in context.Champions)
    {
        Console.WriteLine($"{c.Name} - {c.Class}");
    }

    Console.WriteLine("\nWith new Champions :\n");

    DataSeeder.SeedData(context);
    foreach (var c in context.Champions)
    {
        Console.WriteLine($"{c.Name} - {c.Class}");
    }

    context.SaveChangesAsync(); // or context.SaveChangesAsync
}