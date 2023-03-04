using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class SkinMapper
    {
        public static SkinDto ToDto(this Skin skin)
        {
            return new SkinDto()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.ToDto(),
                Price = skin.Price
            };
        }

        public static SkinDtoC ToDtoC(this Skin skin)
        {
            return new SkinDtoC()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Image = skin.Image.ToDto(),
                Price = skin.Price,
                ChampionName = skin.Champion.Name
            };
        }

        public static Skin ToModel(this SkinDto skinDto)
        {
            return new Skin(skinDto.Name, null, skinDto.Price, skinDto.Icon, skinDto.Image.Base64, skinDto.Description);
        }

    }
}