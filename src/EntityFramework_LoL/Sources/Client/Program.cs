/*// See https://aka.ms/new-console-template for more information
using static ApiManager.ApiManagerData;

Console.WriteLine("Hello, World!");
var championClient = new ChampionsManager(new HttpClient());

// Get all champions
var champions = await championClient.GetItems(0,6);
Console.WriteLine("All champions:");
foreach (var champion in champions)
{
    Console.WriteLine($"{champion.Name} ({champion.Bio})");
}

*//*// Add a new champion
var newChampion = new ChampionDto { Name = "Akali", Role = "Assassin" };
championClient.Add(newChampion);

// Delete a champion
var championToDelete = champions.FirstOrDefault(c => c.Name == "Riven");
if (championToDelete != null)
{
    championClient.Delete(championToDelete);
    Console.WriteLine($"{championToDelete.Name} deleted.");
}

// Update a champion
var championToUpdate = champions.FirstOrDefault(c => c.Name == "Ashe");
if (championToUpdate != null)
{
    championToUpdate.Role = "Marksman";
    championClient.Update(championToUpdate);
    Console.WriteLine($"{championToUpdate.Name} updated.");
}

*//*

Console.ReadLine();*/