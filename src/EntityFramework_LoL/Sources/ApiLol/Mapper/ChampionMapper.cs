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
            };
        }

        public static Champion ToModel(this ChampionDto championDto)
        {
            
        }

    }
}
