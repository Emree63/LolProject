using ApiLol.Mapper.enums;
using DTO;
using Model;
using static Model.RunePage;

namespace ApiLol.Mapper
{
    public static class RunePageMapper
    {
        public static RunePageDto ToDto(this RunePage runePage)
        {

            return new RunePageDto()
            {
                Name = runePage.Name,
                Runes = runePage.Runes.ToDictionary(c => c.Key.ToString(), r => r.Value.ToDto())
            };
        }

        public static RunePage ToModel(this RunePageDto runePageDto)
        {
            Category category;
            Dictionary<Category, Rune> runDico = runePageDto.Runes.ToDictionary(
                r => (RunePage.Category)Enum.Parse(typeof(RunePage.Category), r.Key),
                r => r.Value.ToModel()
            );

            var runePage = new RunePage(runePageDto.Name);
            foreach (var rune in runePageDto.Runes)
            {
                if (!Enum.TryParse<Category>(rune.Key, true, out category))
                {
                    continue;
                }
                runePage[category] = rune.Value.ToModel();
            }

            return runePage;
        }
    }
}
