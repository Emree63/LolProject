using DTO;
using Model;
using System.Net.Http.Json;
using ApiMapping;
using System.Data.SqlTypes;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class RunePagesManager : HttpClientManager, IRunePagesManager
        {
            private const string UrlApiRunePages = "/api/RunePages";
            public RunePagesManager(HttpClient httpClient) : base(httpClient) { }

            public async Task<RunePage?> AddItem(RunePage? item)
            {
                try
                {
                    var resp = await _httpClient.PostAsJsonAsync($"{UrlApiRunePages}", item.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var createdItem = await resp.Content.ReadFromJsonAsync<RunePageDto>();
                        return createdItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding runePage: {ex.Message}");
                    return null;
                }
            }

            public async Task<bool> DeleteItem(RunePage? item)
            {
                try
                {
                    var resp = await _httpClient.DeleteAsync($"{UrlApiRunePages}/{item?.Name}");
                    return resp.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting runePage: {ex.Message}");
                    return false;
                }
            }

            private static Func<RunePage, string, bool> filterByName
                = (rp, substring) => rp.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<RunePage, string, bool> filterByNameContains
                = (rp, substring) => rp.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<RunePage, Rune?, bool> filterByRune
                = (rp, rune) => rune != null && rp.Runes.Values.Contains(rune!);

            public async Task<IEnumerable<RunePage?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>(UrlApiRunePages);
                return runePages.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rp => filterByName(rp, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<RunePage?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>($"{UrlApiRunePages}?&index={index}&count={count}&descending={descending}");
                return runePages.Data.Select(c => c.ToModel());
            }

            public async Task<IEnumerable<RunePage?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public async Task<IEnumerable<RunePage?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>(UrlApiRunePages);
                return runePages.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rp => filterByNameContains(rp, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<RunePage?>> GetItemsByRune(Rune? rune, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>(UrlApiRunePages);
                return runePages.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rp => filterByRune(rp, rune),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<int> GetNbItems()
            {
                var response = await _httpClient.GetAsync("/countRunePages");
                var content = await response.Content.ReadAsStringAsync();
                return int.Parse(content);
            }

            public Task<int> GetNbItemsByChampion(Champion? champion)
            {
                throw new NotImplementedException();
            }

            public async Task<int> GetNbItemsByName(string substring)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>(UrlApiRunePages);
                return await runePages.Data.Select(r => r.ToModel()).GetNbItemsWithFilter(
                    rp => filterByName(rp, substring));
            }

            public async Task<int> GetNbItemsByRune(Rune? rune)
            {
                var runePages = await _httpClient.GetFromJsonAsync<PageResponse<RunePageDto>>(UrlApiRunePages);
                return await runePages.Data.Select(r => r.ToModel()).GetNbItemsWithFilter(
                    rp => filterByRune(rp, rune));
            }

            public async Task<RunePage?> UpdateItem(RunePage? oldItem, RunePage? newItem)
            {
                try
                {
                    var resp = await _httpClient.PutAsJsonAsync($"{UrlApiRunePages}/{oldItem?.Name}", newItem.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var updatedItem = await resp.Content.ReadFromJsonAsync<RunePageDto>();
                        return updatedItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating runePage: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
