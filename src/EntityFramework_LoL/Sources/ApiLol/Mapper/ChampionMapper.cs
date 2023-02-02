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
            };
        }

        public static Champion ToModel(this ChampionDto championDto)
        {
            return new Champion(championDto.Name)
            {
                Bio = championDto.Bio,
            };
        }

    }
}
