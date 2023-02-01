// See https://aka.ms/new-console-template for more information
using MyFlib;

Console.WriteLine("Hello, World!");

using(var context = new LolDbContext())
{
    //var champions = context.Champions.where
    context.SaveChangesAsync(); // or context.SaveChangesAsync
}