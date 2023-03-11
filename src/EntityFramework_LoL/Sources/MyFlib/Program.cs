// See https://aka.ms/new-console-template for more information
using MyFlib;
using static System.Console;

using (var context = new LolDbContext())
{

    WriteLine("\nChampions :\n");

    foreach (var c in context.Champions)
    {
        WriteLine($"{c.Name} - {c.Class}");
    }

    WriteLine("\nWith new Champions :\n");

    DataSeeder.SeedData(context);
    foreach (var c in context.Champions)
    {
        WriteLine($"{c.Name} - {c.Class}");
       /* foreach (var s in c.Skills)
        {
            WriteLine($"\t\t{s.Name} - {s.Description}");
        }*/
    }

    WriteLine("\nSkills :\n");

    foreach (var c in context.Skills)
    {
        WriteLine($"{c.Name} - {c.Description} - {c.Type}");
    }

    WriteLine("\nSkins :\n");

    foreach (var c in context.Skins)
    {
        WriteLine($"{c.Name} - {c.Description} - Price: {c.Price} - ChampionId: {c.ChampionForeignKey}");
    }

    WriteLine("\nRunes :\n");

    context.SaveChangesAsync(); // or context.SaveChangesAsync
}