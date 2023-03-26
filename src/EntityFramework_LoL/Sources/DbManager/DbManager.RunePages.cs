using DbManager.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbLib
{
    public partial class DbManager
    {
        public class RunePagesManager : IRunePagesManager
        {
            private readonly DbManager parent;

            public RunePagesManager(DbManager parent)
                => this.parent = parent;

            public async Task<RunePage?> AddItem(RunePage? item)
            {
                var RunePage = await parent.DbContext.RunePages.AddAsync(item.ToEntity(parent.DbContext));
                parent.DbContext.SaveChanges();
                return RunePage.Entity.ToModel(parent.DbContext);
            }

            public async Task<bool> DeleteItem(RunePage? item)
            {
                var toDelete = parent.DbContext.RunePages.Find(item.Name);
                if (toDelete != null)
                {
                    parent.DbContext.RunePages.Remove(toDelete);
                    parent.DbContext.SaveChanges();
                    return true;
                }
                return false;
            }

            private static Func<RunePage, string, bool> filterByName
                = (rp, substring) => rp.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<RunePage, string, bool> filterByNameContains
                = (rp, substring) => rp.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<RunePage, Rune?, bool> filterByRune
                = (rp, rune) => rune != null && rp.Runes.Values.Contains(rune!);

            public async Task<IEnumerable<RunePage?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.RunePages.Include(rp => rp.Champions).Include(rp => rp.DictionaryCategoryRunes).GetItemsWithFilterAndOrdering(
                    rp => filterByName(rp.ToModel(parent.DbContext), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel(parent.DbContext));

            public async Task<IEnumerable<RunePage?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
            {
                parent.DbContext.Runes.Include(r => r.Image);
                return parent.DbContext.RunePages.Include(rp => rp.Champions).Include(rp => rp.DictionaryCategoryRunes).Include(rp => rp.DictionaryCategoryRunes).GetItemsWithFilterAndOrdering(
                    rp => true,
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel(parent.DbContext));
            }

            public async Task<IEnumerable<RunePage?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.RunePages.Include(rp => rp.Champions).Include(rp => rp.DictionaryCategoryRunes).GetItemsWithFilterAndOrdering(
                    rp => rp.Champions.Any(c => c.Name.Equals(champion.Name)),
                    index, count,
                    orderingPropertyName, descending).Select(rp => rp.ToModel(parent.DbContext));

            public async Task<IEnumerable<RunePage?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.RunePages.Include(rp => rp.Champions).Include(rp => rp.DictionaryCategoryRunes).GetItemsWithFilterAndOrdering(
                    rp => filterByNameContains(rp.ToModel(parent.DbContext), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel(parent.DbContext));

            public async Task<IEnumerable<RunePage?>> GetItemsByRune(Rune? rune, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.RunePages.Include(rp => rp.Champions).Include(rp => rp.DictionaryCategoryRunes).GetItemsWithFilterAndOrdering(
                    rp => filterByRune(rp.ToModel(parent.DbContext), rune),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel(parent.DbContext));

            public Task<int> GetNbItems()
                => parent.DbContext.RunePages.GetNbItemsWithFilter(
                    rp => true);

            public async Task<int> GetNbItemsByChampion(Champion? champion)
                => parent.DbContext.RunePages.Where(rp => rp.Champions.Any(c => c.Name.Equals(champion.Name))).Count();


            public async Task<int> GetNbItemsByName(string substring)
                => parent.DbContext.RunePages.Where(rp => rp.Name.Contains(substring)).Count();

            public async Task<int> GetNbItemsByRune(Rune? rune)
                => parent.DbContext.RunePages.Where(rp => rp.DictionaryCategoryRunes.Any(r => r.RuneName.Equals(rune.Name))).Count();

            public async Task<RunePage?> UpdateItem(RunePage? oldItem, RunePage? newItem)
            {
                var toUpdate = parent.DbContext.RunePages.Find(oldItem.Name);
                toUpdate.DictionaryCategoryRunes = newItem.ToEntity(parent.DbContext).DictionaryCategoryRunes;
                parent.DbContext.SaveChanges();
                return toUpdate.ToModel(parent.DbContext);
            }
        }
    }
}
