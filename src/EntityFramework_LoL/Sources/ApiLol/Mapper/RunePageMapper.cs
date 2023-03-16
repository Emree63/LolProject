using ApiLol.Mapper.enums;
using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class RunePageMapper
    {
        public static RunePageDto ToDto(this RunePage runePage)
        {

            return new RunePageDto()
            {
                Name = runePage.Name,
                Runes = runePage.Runes.ToDictionary(c => c.Key.ToDto(), r => r.Value.ToDto())
            };
        }

        public static RunePage ToModel(this RunePageDto runePageDto)
        {

            var runePage = new RunePage(runePageDto.Name);
            foreach( var rune in runePageDto.Runes)
            {
                runePage[rune.Key.ToModel()] = rune.Value.ToModel();
            }

            return runePage;
        }
    }
}
