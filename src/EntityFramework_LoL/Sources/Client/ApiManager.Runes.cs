using Model;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class RunesManager : HttpClientManager, IRunesManager
        {
            private const string UrlApiRunes = "/api/runes";
            public RunesManager(HttpClient httpClient) : base(httpClient) { }

            public Task<Rune?> AddItem(Rune? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Rune? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Rune?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Rune?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Rune?>> GetItemsByFamily(RuneFamily family, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Rune?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItems()
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByFamily(RuneFamily family)
            {
                throw new NotImplementedException();
            }

            public Task<int> GetNbItemsByName(string substring)
            {
                throw new NotImplementedException();
            }

            public Task<Rune?> UpdateItem(Rune? oldItem, Rune? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}