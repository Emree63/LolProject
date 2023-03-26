using DTO;
using Model;

namespace ApiMapping.enums
{
    public static class ChampionClassMapper
    {
        public static ChampionClassDto ToDto(this ChampionClass championClass)
        {
            switch (championClass)
            {
                case ChampionClass.Unknown:
                    return ChampionClassDto.Unknown;
                case ChampionClass.Assassin:
                    return ChampionClassDto.Assassin;
                case ChampionClass.Fighter:
                    return ChampionClassDto.Fighter;
                case ChampionClass.Mage:
                    return ChampionClassDto.Mage;
                case ChampionClass.Marksman:
                    return ChampionClassDto.Marksman;
                case ChampionClass.Support:
                    return ChampionClassDto.Support;
                case ChampionClass.Tank:
                    return ChampionClassDto.Tank;
                default:
                    return ChampionClassDto.Unknown;
            }
        }
        public static ChampionClass ToModel(this ChampionClassDto championClass)
        {
            switch (championClass)
            {
                case ChampionClassDto.Unknown:
                    return ChampionClass.Unknown;
                case ChampionClassDto.Assassin:
                    return ChampionClass.Assassin;
                case ChampionClassDto.Fighter:
                    return ChampionClass.Fighter;
                case ChampionClassDto.Mage:
                    return ChampionClass.Mage;
                case ChampionClassDto.Marksman:
                    return ChampionClass.Marksman;
                case ChampionClassDto.Support:
                    return ChampionClass.Support;
                case ChampionClassDto.Tank:
                    return ChampionClass.Tank;
                default:
                    return ChampionClass.Unknown;
            }
        }
    }
}
