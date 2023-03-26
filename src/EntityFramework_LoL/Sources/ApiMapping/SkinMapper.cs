using ApiMapping;
using DTO;
using Model;

namespace ApiMapping
{
    public static class SkinMapper
    {
        public static SkinDto ToDto(this Skin skin)
            => new()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.ToDto(),
                Price = skin.Price
            };

        public static SkinDtoC ToDtoC(this Skin skin)
            => new()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.ToDto(),
                Price = skin.Price,
                ChampionName = skin.Champion.Name
            };

        public static Skin ToModel(this SkinDto skinDto, Champion champ) => new(skinDto.Name, champ, skinDto.Price, skinDto.Icon, skinDto.Image.Base64, skinDto.Description);

        public static Skin ToModelC(this SkinDtoC skinDto, Champion champ) => new(skinDto.Name, champ, skinDto.Price, skinDto.Icon, skinDto.Image.Base64, skinDto.Description);

    }
}