using DTO;
using Model;
using System.Net.Http.Json;
using ApiMapping;
using System.Data.SqlTypes;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class SkinsManager : HttpClientManager, ISkinsManager
        {
            private const string UrlApiSkins = "/api/Skins";
            public SkinsManager(HttpClient httpClient) : base(httpClient) { }

            public async Task<Skin?> AddItem(Skin? item)
            {
                try
                {
                    var resp = await _httpClient.PostAsJsonAsync($"{UrlApiSkins}", item.ToDtoC());
                    if (resp.IsSuccessStatusCode)
                    {
                        var createdItem = await resp.Content.ReadFromJsonAsync<SkinDtoC>();
                        var championManager = new ChampionsManager(_httpClient);
                        var champ = await championManager.GetItemByName(createdItem.ChampionName, 0, 1);
                        return createdItem?.ToModelC(champ.First());
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding skin: {ex.Message}");
                    return null;
                }
            }

            public async Task<bool> DeleteItem(Skin? item)
            {
                try
                {
                    var resp = await _httpClient.DeleteAsync($"{UrlApiSkins}/{item?.Name}");
                    return resp.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting skin: {ex.Message}");
                    return false;
                }
            }

            public async Task<IEnumerable<Skin?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>(UrlApiSkins);
                var skins = new List<Skin>();
                var championManager = new ChampionsManager(_httpClient);
                foreach (var skin in dtoSkins.Data)
                {
                    var champ = await championManager.GetItemByName(skin.ChampionName, 0, 1);
                    skins.Add(skin.ToModelC(champ.First()));
                }
                return skins.GetItemsWithFilterAndOrdering(
                    skin => filterByName(skin, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>($"{UrlApiSkins}?&index={index}&count={count}&descending={descending}");
                var skins = new List<Skin>();
                var championManager = new ChampionsManager(_httpClient);
                foreach (var skin in dtoSkins.Data)
                {
                    var champ = await championManager.GetItemByName(skin.ChampionName, 0, 1);
                    skins.Add(skin.ToModelC(champ.First()));
                }
                return skins;
            }

            public async Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>(UrlApiSkins);
                var skins = new List<Skin>();
                var championManager = new ChampionsManager(_httpClient);
                foreach (var skin in dtoSkins.Data)
                {
                    var champ = await championManager.GetItemByName(skin.ChampionName, 0, 1);
                    skins.Add(skin.ToModelC(champ.First()));
                }
                return skins.GetItemsWithFilterAndOrdering(
                    skin => filterByChampion(skin, champion),
                    index, count, orderingPropertyName, descending);
            }

            private static Func<Skin, Champion?, bool> filterByChampion = (skin, champion) => champion != null && skin.Champion.Equals(champion!);

            private static Func<Skin, string, bool> filterByName = (skin, substring) => skin.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<Skin, string, bool> filterByNameContains = (skin, substring) => skin.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false) 
            { 
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>(UrlApiSkins); 
                var skins = new List<Skin>(); 
                var championManager = new ChampionsManager(_httpClient); 
                foreach (var skin in dtoSkins.Data) 
                { 
                    var champ = await championManager.GetItemByName(skin.ChampionName,0,1); 
                    skins.Add(skin.ToModelC(champ.First())); 
                }
                return skins.GetItemsWithFilterAndOrdering(
                    skin => filterByNameContains(skin, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<int> GetNbItems()
            {
                var response = await _httpClient.GetAsync("/countSkins");
                var content = await response.Content.ReadAsStringAsync();
                return int.Parse(content);
            }

            public async Task<int> GetNbItemsByChampion(Champion? champion)
            {
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>(UrlApiSkins);
                var skins = new List<Skin>();
                var championManager = new ChampionsManager(_httpClient);
                foreach (var skin in dtoSkins.Data)
                {
                    var champ = await championManager.GetItemByName(skin.ChampionName, 0, 1);
                    skins.Add(skin.ToModelC(champ.First()));
                }
                return await skins.GetNbItemsWithFilter(
                    skin => filterByChampion(skin, champion));
            }

            public async Task<int> GetNbItemsByName(string substring)
            {
                var dtoSkins = await _httpClient.GetFromJsonAsync<PageResponse<SkinDtoC>>(UrlApiSkins);
                var skins = new List<Skin>();
                var championManager = new ChampionsManager(_httpClient);
                foreach (var skin in dtoSkins.Data)
                {
                    var champ = await championManager.GetItemByName(skin.ChampionName, 0, 1);
                    skins.Add(skin.ToModelC(champ.First()));
                }
                return await skins.GetNbItemsWithFilter(
                    skin => filterByName(skin, substring));
            }

            public async Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
            {
                try
                {
                    var resp = await _httpClient.PutAsJsonAsync($"{UrlApiSkins}/{oldItem?.Name}", newItem.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var updatedItem = await resp.Content.ReadFromJsonAsync<SkinDtoC>();
                        var championManager = new ChampionsManager(_httpClient);
                        var champ = await championManager.GetItemByName(updatedItem.ChampionName, 0, 1);
                        return updatedItem?.ToModelC(champ.First());
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating skin: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
