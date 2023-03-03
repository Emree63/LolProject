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
                Image = champion.Image.ToDto(),
                Skins = champion.Skins.Select(e => e.ToDto()),
                Skills = champion.Skills.Select(e => e.ToDto())
            };
        }

        public static Champion ToModel(this ChampionDto championDto)
        {
            return new Champion(championDto.Name, championDto.Class.ToModel(), championDto.Icon, championDto.Image.Base64, championDto.Bio);
        }

    }
}
