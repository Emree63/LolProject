// See https://aka.ms/new-console-template for more information
using MyFlib;

using (var context = new LolDbContext())
{

    foreach (var c in context.Champions)
    {
        Console.WriteLine($"{c.Name} - {c.Bio}");
    }
    context.SaveChangesAsync(); // or context.SaveChangesAsync
}