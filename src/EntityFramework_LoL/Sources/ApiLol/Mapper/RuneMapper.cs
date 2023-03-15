using ApiLol.Mapper.enums;
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
                Family = rune.Family.ToDto(),
                Icon = rune.Icon,
                Image = rune.Image.ToDto()
            };
        }

        public static Rune ToModel(this RuneDto rune)
        {
            return new Rune(rune.Name, rune.Family.ToModel(), rune.Icon, rune.Image.Base64, rune.Description);
        }
    }
}
