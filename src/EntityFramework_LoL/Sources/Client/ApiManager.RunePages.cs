using Model;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class RunePagesManager : HttpClientManager, IRunePagesManager
        {
            private const string UrlApiRunePages = "/api/RunePages";
            public RunePagesManager(HttpClient httpClient) : base(httpClient) { }

            public Task<RunePage?> AddItem(RunePage? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(RunePage? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<RunePage?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<RunePage?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<RunePage?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<RunePage?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<RunePage?>> GetItemsByRune(Rune? rune, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByChampion(Champion? champion)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByName(string substring)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByRune(Rune? rune)
            {
                throw new NotImplementedException();
            }

            public Task<RunePage?> UpdateItem(RunePage? oldItem, RunePage? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
