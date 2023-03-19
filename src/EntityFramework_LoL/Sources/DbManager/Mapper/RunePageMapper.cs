using DbManager.Mapper.enums;
using Model;
using MyFlib;
using MyFlib.Entities;

namespace DbManager.Mapper
{
    public static class RunePageMapper
    {
        public static RunePage ToModel(this RunePageEntity runePageEntity, LolDbContext context)
        {
            RunePage runePage = new(runePageEntity.Name);
            foreach (var d in runePageEntity.DictionaryCategoryRunes)
            {
                var rune = context.Runes.Find(d.RuneName);
                if (rune!=null)
                {
                    runePage[d.category.ToModel()] = rune.ToModel();
                }
            }
            return runePage;
        }
    }
}
