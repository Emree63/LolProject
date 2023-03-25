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

        public static RunePageEntity ToEntity(this RunePage runePage, LolDbContext context)
        {
            RunePageEntity? runePageEntity = context.RunePages.Find(runePage.Name);
            if (runePageEntity == null)
            {
                runePageEntity = new()
                {
                    Name = runePage.Name,
                };

                runePageEntity.DictionaryCategoryRunes = new List<DictionaryCategoryRune>();
                foreach (var r in runePage.Runes)
                {
                    runePageEntity.DictionaryCategoryRunes.Add(new DictionaryCategoryRune()
                    {
                        category = r.Key.ToEntity(),
                        rune = r.Value.ToEntity(),
                    });
                }

            }
            return runePageEntity;
        }
    }
}
