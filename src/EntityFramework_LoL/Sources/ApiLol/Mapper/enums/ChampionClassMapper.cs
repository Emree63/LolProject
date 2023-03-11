using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class ChampionClassMapper
    {
        public static ChampionClassDto ToDto(this ChampionClass championClass)
        {
            if (championClass == ChampionClass.Unknown)
            {
                return ChampionClassDto.Unknown;
            }
            if (championClass == ChampionClass.Assassin)
            {
                return ChampionClassDto.Assassin;
            }
            if (championClass == ChampionClass.Fighter)
            {
                return ChampionClassDto.Fighter;
            }
            if (championClass == ChampionClass.Mage)
            {
                return ChampionClassDto.Mage;
            }
            if (championClass == ChampionClass.Marksman)
            {
                return ChampionClassDto.Marksman;
            }
            if (championClass == ChampionClass.Support)
            {
                return ChampionClassDto.Support;
            }
            if (championClass == ChampionClass.Tank)
            {
                return ChampionClassDto.Tank;
            }
            else
            {
                return ChampionClassDto.Unknown;
            }

        }
        public static ChampionClass ToModel(this ChampionClassDto championClass)
        {
            if (championClass == ChampionClassDto.Unknown)
            {
                return ChampionClass.Unknown;
            }
            if (championClass == ChampionClassDto.Assassin)
            {
                return ChampionClass.Assassin;
            }
            if (championClass == ChampionClassDto.Fighter)
            {
                return ChampionClass.Fighter;
            }
            if (championClass == ChampionClassDto.Mage)
            {
                return ChampionClass.Mage;
            }
            if (championClass == ChampionClassDto.Marksman)
            {
                return ChampionClass.Marksman;
            }
            if (championClass == ChampionClassDto.Support)
            {
                return ChampionClass.Support;
            }
            if (championClass == ChampionClassDto.Tank)
            {
                return ChampionClass.Tank;
            }
            else
            {
                return ChampionClass.Unknown;
            }
        }
    }
}
