using ApiMapping;
using ApiMapping.enums;
using DTO;
using Model;

namespace ApiMapping
{
    public static class RuneMapper
    {
        public static RuneDto ToDto(this Rune rune)
            => new()
            {
                Name = rune.Name,
                Description = rune.Description,
                Family = rune.Family.ToDto(),
                Icon = rune.Icon,
                Image = rune.Image.ToDto()
            };

        public static Rune ToModel(this RuneDto rune) => new(rune.Name, rune.Family.ToModel(), rune.Icon, rune.Image.Base64, rune.Description);

    }
}
