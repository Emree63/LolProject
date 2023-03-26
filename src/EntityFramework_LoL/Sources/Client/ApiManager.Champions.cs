using ApiLol.Mapper;
using DTO;
using Model;
using System.Net.Http.Json;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class ChampionsManager : HttpClientManager, IChampionsManager
        {
            private const string UrlApiChampions = "/api/v2/champions";
            public ChampionsManager(HttpClient httpClient) : base(httpClient) { }

            public async Task<Champion?> AddItem(Champion? item)
            {
                try
                {
                    var resp = await _httpClient.PostAsJsonAsync($"{UrlApiChampions}", item.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var createdItem = await resp.Content.ReadFromJsonAsync<ChampionDto>();
                        return createdItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding champion: {ex.Message}");
                    return null;
                }
            }

            public async Task<bool> DeleteItem(Champion? item)
            {
                try
                {
                    var resp = await _httpClient.DeleteAsync($"{UrlApiChampions}/{item?.Name}");
                    return resp.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting champion: {ex.Message}");
                    return false;
                }
            }

            private Func<Champion, string, bool> filterByNameContains = (champ, substring) => champ.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            private Func<Champion, string, bool> filterByName = (champ, substring) => champ.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Champion?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(champ => filterByName(champ, substring), index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var url = $"{UrlApiChampions}?index={index}&count={count}&orderingPropertyName={orderingPropertyName}&descending={descending}";
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(url);
                return response.Select(c => c.ToModel());
            }

            private Func<Champion, string, bool> filterByCharacteristic = (champ, charName) => champ.Characteristics.Keys.Any(k => k.Contains(charName, StringComparison.InvariantCultureIgnoreCase));

            public async Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(
                        champ => filterByCharacteristic(champ, charName),
                        index, count, orderingPropertyName, descending);
            }

            private Func<Champion, ChampionClass, bool> filterByClass = (champ, championClass) => champ.Class == championClass;

            public async Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(
                    champ => filterByClass(champ, championClass),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(champ => filterByNameContains(champ, substring), index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            private Func<Champion, Skill?, bool> filterBySkill = (champ, skill) => skill != null && champ.Skills.Contains(skill!);

            private static Func<Champion, string, bool> filterBySkillSubstring = (champ, skill) => champ.Skills.Any(s => s.Name.Contains(skill, StringComparison.InvariantCultureIgnoreCase));

            public async Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(champ => filterBySkill(champ, skill), index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Champion?>> GetItemsBySkill(string skillSubstring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Select(c => c.ToModel()).GetItemsWithFilterAndOrdering(champ => filterBySkillSubstring(champ, skillSubstring), index, count, orderingPropertyName, descending);
            }

            public async Task<int> GetNbItems()
            {
                var response = await _httpClient.GetAsync("/countChampions");
                var content = await response.Content.ReadAsStringAsync();
                return int.Parse(content);
            }

            public async Task<int> GetNbItemsByCharacteristic(string charName)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return await response.GetNbItemsWithFilter(champ => filterByCharacteristic(champ.ToModel(), charName));

            }

            public async Task<int> GetNbItemsByClass(ChampionClass championClass)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Where(c => c.Class.Equals(championClass))
                    .Count();
            }

            public async Task<int> GetNbItemsByName(string substring)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return response.Where(c => c.Name.Equals(substring))
                    .Count();
            }

            public Task<int> GetNbItemsByRunePage(RunePage? runePage)
            {
                throw new NotImplementedException();
            }

            public async Task<int> GetNbItemsBySkill(Skill? skill)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return await response.GetNbItemsWithFilter(champ => filterBySkill(champ.ToModel(), skill));
            }

            public async Task<int> GetNbItemsBySkill(string skill)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ChampionDto>>(UrlApiChampions);
                return await response.GetNbItemsWithFilter(champ => filterBySkillSubstring(champ.ToModel(), skill));
            }

            public async Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)
            {
                try
                {
                    var resp = await _httpClient.PutAsJsonAsync($"{UrlApiChampions}/{oldItem?.Name}", newItem.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var updatedItem = await resp.Content.ReadFromJsonAsync<ChampionDto>();
                        return updatedItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating champion: {ex.Message}");
                    return null;
                }
            }

        }
    }
}
