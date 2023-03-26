using DbManager.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbLib
{
    public partial class DbManager
    {
        public class RunesManager : IRunesManager
        {
            private readonly DbManager parent;
            public RunesManager(DbManager parent)
                => this.parent = parent;

            public async Task<Rune?> AddItem(Rune? item)
            {
                var rune = await parent.DbContext.Runes.AddAsync(item.ToEntity());
                parent.DbContext.SaveChanges();
                return rune.Entity.ToModel();
            }

            public async Task<bool> DeleteItem(Rune? item)
            {
                var toDelete = parent.DbContext.Runes.Find(item.Name);
                if (toDelete != null)
                {
                    parent.DbContext.Runes.Remove(toDelete);
                    parent.DbContext.SaveChanges();
                    return true;
                }
                return false;
            }

            private static Func<Rune, RuneFamily, bool> filterByRuneFamily
                = (rune, family) => rune.Family == family;

            private static Func<Rune, string, bool> filterByName
                = (rune, substring) => rune.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<Rune, string, bool> filterByNameContains
                = (rune, substring) => rune.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Rune?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Runes.Include(r => r.Image).GetItemsWithFilterAndOrdering(
                    rune => filterByName(rune.ToModel(), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Rune?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Runes.Include(r => r.Image).GetItemsWithFilterAndOrdering(
                    r => true,
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Rune?>> GetItemsByFamily(RuneFamily family, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Runes.Include(r => r.Image).GetItemsWithFilterAndOrdering(
                    rune => filterByRuneFamily(rune.ToModel(), family),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Rune?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Runes.Include(r => r.Image).GetItemsWithFilterAndOrdering(
                    rune => filterByNameContains(rune.ToModel(), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public Task<int> GetNbItems()
                => parent.DbContext.Runes.GetNbItemsWithFilter(
                    rune => true);

            public Task<int> GetNbItemsByFamily(RuneFamily family)
                => parent.DbContext.Runes.GetNbItemsWithFilter(
                    rune => filterByRuneFamily(rune.ToModel(), family));

            public Task<int> GetNbItemsByName(string substring)
                => parent.DbContext.Runes.GetNbItemsWithFilter(
                    rune => filterByName(rune.ToModel(), substring));

            public async Task<Rune?> UpdateItem(Rune? oldItem, Rune? newItem)
            {
                var toUpdate = parent.DbContext.Runes.Find(oldItem.Name);
                var newEntity = newItem.ToEntity();
                toUpdate.Description = newEntity.Description;
                toUpdate.Icon = newEntity.Icon;
                toUpdate.Family = newEntity.Family;
                toUpdate.Image = newEntity.Image;

                parent.DbContext.SaveChanges();
                return toUpdate.ToModel();
            }
        }

    }
}
