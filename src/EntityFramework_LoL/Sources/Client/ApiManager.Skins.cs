using Model;

namespace ApiManager
{
    public partial class ApiManagerData
    {
        public class SkinsManager : HttpClientManager, ISkinsManager
        {
            private const string UrlApiSkins = "/api/Skins";
            public SkinsManager(HttpClient httpClient) : base(httpClient) { }

            public Task<Skin?> AddItem(Skin? item)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DeleteItem(Skin? item)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
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

            public Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
            {
                throw new NotImplementedException();
            }
        }
    }
}
