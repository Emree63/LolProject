using DbManager.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLib
{
    public partial class DbManager
    {
        public class SkinsManager : ISkinsManager
        {
            private readonly DbManager parent;

            public SkinsManager(DbManager parent)
                => this.parent = parent;

            public async Task<Skin?> AddItem(Skin? item)
            {
                var skin = await parent.DbContext.Skins.AddAsync(item.ToEntity(parent.DbContext));
                parent.DbContext.SaveChanges();
                return skin.Entity.ToModel();
            }

            public async Task<bool> DeleteItem(Skin? item)
            {
                var toDelete = parent.DbContext.Skins.Find(item.Name);
                if (toDelete != null)
                {
                    parent.DbContext.Skins.Remove(toDelete);
                    parent.DbContext.SaveChanges();
                    return true;
                }
                return false;
            }

            private static Func<Skin, Champion?, bool> filterByChampion = (skin, champion) => champion != null && skin.Champion.Equals(champion!);

            private static Func<Skin, string, bool> filterByName = (skin, substring) => skin.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            private static Func<Skin, string, bool> filterByNameContains = (skin, substring) => skin.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Skin?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Skins.Include(s => s.Champion).Include(s => s.Image).GetItemsWithFilterAndOrdering(
                    skin => filterByName(skin.ToModel(), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Skins.Include(s => s.Champion).Include(s => s.Image).GetItemsWithFilterAndOrdering(
                    skin => true,
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Skins.Include(s => s.Champion).Include(s => s.Image).GetItemsWithFilterAndOrdering(
                    skin => filterByChampion(skin.ToModel(), champion),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Skins.Include(s => s.Champion).Include(s => s.Image).GetItemsWithFilterAndOrdering(
                    skin => filterByNameContains(skin.ToModel(), substring),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public Task<int> GetNbItems()
                => parent.DbContext.Skins.GetNbItemsWithFilter(
                    c => true);

            public Task<int> GetNbItemsByChampion(Champion? champion)
                => parent.DbContext.Skins.GetNbItemsWithFilter(
                    skin => filterByChampion(skin.ToModel(), champion));

            public Task<int> GetNbItemsByName(string substring)
                => parent.DbContext.Skins.GetNbItemsWithFilter(
                    skin => filterByName(skin.ToModel(), substring));

            public async Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
            {
                var toUpdate = parent.DbContext.Skins.Find(oldItem.Name);
                var newEntity = newItem.ToEntity(parent.DbContext);
                toUpdate.Description = newEntity.Description;
                toUpdate.Icon = newEntity.Icon;
                toUpdate.Price = newEntity.Price;
                toUpdate.Champion = newEntity.Champion;
                toUpdate.Image = newEntity.Image;
                parent.DbContext.SaveChanges();
                return toUpdate.ToModel();
            }
        }

    }
}
