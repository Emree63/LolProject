using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class ChampionMapper
    {
        public static ChampionDto ToDto(this Champion champion)
        {
            return new ChampionDto()
            {
                Name = champion.Name,
                Bio = champion.Bio,
                Class = champion.Class.ToDto(),
                Icon = champion.Icon,
                Image = champion.Image.Base64
            };
        }

        public static Champion ToModel(this ChampionDto championDto)
        {
            return new Champion(championDto.Name, championDto.Class.ToModel(), championDto.Icon, championDto.Image,championDto.Bio);
        }

    }
}
