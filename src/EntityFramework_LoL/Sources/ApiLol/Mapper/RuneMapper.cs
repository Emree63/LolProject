using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class RuneMapper
    {
        public static RuneDto ToDto(this Rune rune)
        {
            return new RuneDto()
            {
                Name = rune.Name,
                Description = rune.Description,
            };
        }

/*        public static Rune ToModel(this RuneDto rune)
        {
            return new Rune(rune.Name)
            {
                Description = rune.Description,
            };
        }*/
    }
}
