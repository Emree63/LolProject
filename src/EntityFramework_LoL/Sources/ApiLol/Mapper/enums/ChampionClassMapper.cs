using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class ChampionClassMapper
    {
        public static ChampionClassDto ToDto(this ChampionClass championClass)
        {
            return (ChampionClassDto) championClass;
        }
        public static ChampionClass ToModel(this ChampionClassDto championClass)
        {
            return (ChampionClass) championClass;
        }
    }
}
