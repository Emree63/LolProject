using DTO;
using Model;
using System.Net.Http.Json;
using ApiMapping;
using System;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class RunesManager : HttpClientManager, IRunesManager
        {
            private const string UrlApiRunes = "/api/runes";
            public RunesManager(HttpClient httpClient) : base(httpClient) { }

            public async Task<Rune?> AddItem(Rune? item)
            {
                try
                {
                    var resp = await _httpClient.PostAsJsonAsync($"{UrlApiRunes}", item.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var createdItem = await resp.Content.ReadFromJsonAsync<RuneDto>();
                        return createdItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding rune: {ex.Message}");
                    return null;
                }
            }

            public async Task<bool> DeleteItem(Rune? item)
            {
                try
                {
                    var resp = await _httpClient.DeleteAsync($"{UrlApiRunes}/{item?.Name}");
                    return resp.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting rune: {ex.Message}");
                    return false;
                }
            }

            private static Func<Rune, RuneFamily, bool> filterByRuneFamily
                = (rune, family) => rune.Family == family;

            private static Func<Rune, string, bool> filterByName
                = (rune, substring) => rune.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<Rune, string, bool> filterByNameContains
                = (rune, substring) => rune.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Rune?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>(UrlApiRunes);
                return runes.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rune => filterByName(rune, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Rune?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>($"{UrlApiRunes}?&index={index}&count={count}&descending={descending}");
                return runes.Data.Select(c => c.ToModel());

            }

            public async Task<IEnumerable<Rune?>> GetItemsByFamily(RuneFamily family, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>(UrlApiRunes);
                return runes.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rune => filterByRuneFamily(rune, family),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<IEnumerable<Rune?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>(UrlApiRunes);
                return runes.Data.Select(r => r.ToModel()).GetItemsWithFilterAndOrdering(
                    rune => filterByNameContains(rune, substring),
                    index, count, orderingPropertyName, descending);
            }

            public async Task<int> GetNbItems()
            {
                var response = await _httpClient.GetAsync("/countRunes");
                var content = await response.Content.ReadAsStringAsync();
                return int.Parse(content);
            }

            public async Task<int> GetNbItemsByFamily(RuneFamily family)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>(UrlApiRunes);
                return await runes.Data.Select(r => r.ToModel()).GetNbItemsWithFilter(
                    rune => filterByRuneFamily(rune, family));
            }

            public async Task<int> GetNbItemsByName(string substring)
            {
                var runes = await _httpClient.GetFromJsonAsync<PageResponse<RuneDto>>(UrlApiRunes);
                return await runes.Data.Select(r => r.ToModel()).GetNbItemsWithFilter(
                    rune => filterByName(rune, substring));
            }

            public async Task<Rune?> UpdateItem(Rune? oldItem, Rune? newItem)
            {
                try
                {
                    var resp = await _httpClient.PutAsJsonAsync($"{UrlApiRunes}/{oldItem?.Name}", newItem.ToDto());
                    if (resp.IsSuccessStatusCode)
                    {
                        var updatedItem = await resp.Content.ReadFromJsonAsync<RuneDto>();
                        return updatedItem?.ToModel();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating rune: {ex.Message}");
                    return null;
                }
            }
        }
    }
}