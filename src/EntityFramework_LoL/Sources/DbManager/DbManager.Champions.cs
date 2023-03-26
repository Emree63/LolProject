using DbManager.Mapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbLib
{
    public partial class DbManager
    {
        public class ChampionsManager : IChampionsManager
        {
            private readonly DbManager parent;

            public ChampionsManager(DbManager parent)
                => this.parent = parent;

            public async Task<Champion?> AddItem(Champion? item)
            {
                var champion = await parent.DbContext.Champions.AddAsync(item.ToEntity(parent.DbContext));
                parent.DbContext.SaveChanges();
                return champion.Entity.ToModel();
            }

            public async Task<bool> DeleteItem(Champion? item)
            {
                var toDelete = parent.DbContext.Champions.Where(c => c.Name == item.Name).First();
                if (toDelete != null)
                {
                    parent.DbContext.Champions.Remove(toDelete);
                    parent.DbContext.SaveChanges();
                    return true;
                }
                return false;
            }


            private Func<Champion, string, bool> filterByNameContains = (champ, substring) => champ.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            private Func<Champion, string, bool> filterByName = (champ, substring) => champ.Name.Equals(substring, StringComparison.InvariantCultureIgnoreCase);

            public async Task<IEnumerable<Champion?>> GetItemByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(champ => filterByName(champ.ToModel(), substring), index, count, orderingPropertyName, descending)
                        .Select(c => c.ToModel());


            public async Task<IEnumerable<Champion?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(
                        c => true,
                        index, count,
                        orderingPropertyName, descending).Select(c => c.ToModel());

            private Func<Champion, string, bool> filterByCharacteristic = (champ, charName) => champ.Characteristics.Keys.Any(k => k.Contains(charName, StringComparison.InvariantCultureIgnoreCase));

            public async Task<IEnumerable<Champion?>> GetItemsByCharacteristic(string charName, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(
                        champ => filterByCharacteristic(champ.ToModel(), charName),
                        index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            private Func<Champion, ChampionClass, bool> filterByClass = (champ, championClass) => champ.Class == championClass;

            public async Task<IEnumerable<Champion?>> GetItemsByClass(ChampionClass championClass, int index, int count, string? orderingPropertyName = null, bool descending = false)
            => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(
                    champ => filterByClass(champ.ToModel(), championClass),
                    index, count, orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Champion?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(champ => filterByNameContains(champ.ToModel(), substring), index, count, orderingPropertyName, descending)
                        .Select(c => c.ToModel());

            public async Task<IEnumerable<Champion?>> GetItemsByRunePage(RunePage? runePage, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(
                        c => c.RunePages.Any(rp => rp.Equals(runePage.ToEntity(parent.DbContext))),
                        index, count,
                        orderingPropertyName, descending).Select(c => c.ToModel());

            public async Task<IEnumerable<Champion?>> GetItemsBySkill(Skill? skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(champ => filterBySkill(champ.ToModel(), skill), index, count, orderingPropertyName, descending)
                        .Select(c => c.ToModel());


            public async Task<IEnumerable<Champion?>> GetItemsBySkill(string skill, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.DbContext.Champions.Include(c => c.Skills).Include(c => c.Characteristics).Include(c => c.Skins).Include(c => c.Image).GetItemsWithFilterAndOrdering(champ => filterBySkillSubstring(champ.ToModel(), skill), index, count, orderingPropertyName, descending)
                        .Select(c => c.ToModel());

            public async Task<int> GetNbItems()
                => parent.DbContext.Champions.Count();

            public Task<int> GetNbItemsByCharacteristic(string charName)
                => parent.DbContext.Champions.GetNbItemsWithFilter(champ => filterByCharacteristic(champ.ToModel(), charName));

            public async Task<int> GetNbItemsByClass(ChampionClass championClass)
                => parent.DbContext.Champions.Where(c => c.Class.Equals(championClass))
                .Count();

            public async Task<int> GetNbItemsByName(string substring)
                => parent.DbContext.Champions.Where(c => c.Name.Equals(substring))
                .Count();

            public async Task<int> GetNbItemsByRunePage(RunePage? runePage)
                => parent.DbContext.Champions.Where(c => c.RunePages.Any(rp => rp.Equals(runePage.ToEntity(parent.DbContext))))
                    .Count();


            private Func<Champion, Skill?, bool> filterBySkill = (champ, skill) => skill != null && champ.Skills.Contains(skill!);

            public Task<int> GetNbItemsBySkill(Skill? skill)
                => parent.DbContext.Champions.GetNbItemsWithFilter(champ => filterBySkill(champ.ToModel(), skill));

            private static Func<Champion, string, bool> filterBySkillSubstring = (champ, skill) => champ.Skills.Any(s => s.Name.Contains(skill, StringComparison.InvariantCultureIgnoreCase));

            public Task<int> GetNbItemsBySkill(string skill)
                => parent.DbContext.Champions.GetNbItemsWithFilter(champ => filterBySkillSubstring(champ.ToModel(), skill));

            public async Task<Champion?> UpdateItem(Champion? oldItem, Champion? newItem)
            {
                var toUpdate = parent.DbContext.Champions.FirstOrDefault(champ => champ.Name == oldItem.Name);
                var newEntity = newItem.ToEntity(parent.DbContext);
                toUpdate.Bio = newEntity.Bio;
                toUpdate.Class = newEntity.Class;
                toUpdate.Icon = newEntity.Icon;
                toUpdate.Image = newEntity.Image;
                toUpdate.Skins = newEntity.Skins;
                toUpdate.Skills = newEntity.Skills;
                toUpdate.Characteristics = newEntity.Characteristics;
                parent.DbContext.SaveChanges();
                return toUpdate?.ToModel();
            }
        }
    }
}
