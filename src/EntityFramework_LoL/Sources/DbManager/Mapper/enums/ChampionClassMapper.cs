using Model;
using MyFlib;

namespace DbManager.Mapper.enums
{
    public static class ChampionClassMapper
    {
        public static ChampionClass ToModel(this ChampionClassEntity championClass)
        {
            switch (championClass)
            {
                case ChampionClassEntity.Unknown:
                    return ChampionClass.Unknown;
                case ChampionClassEntity.Assassin:
                    return ChampionClass.Assassin;
                case ChampionClassEntity.Fighter:
                    return ChampionClass.Fighter;
                case ChampionClassEntity.Mage:
                    return ChampionClass.Mage;
                case ChampionClassEntity.Marksman:
                    return ChampionClass.Marksman;
                case ChampionClassEntity.Support:
                    return ChampionClass.Support;
                case ChampionClassEntity.Tank:
                    return ChampionClass.Tank;
                default:
                    return ChampionClass.Unknown;
            }
        }

        public static ChampionClassEntity ToEntity(this ChampionClass championClass)
        {
            switch (championClass)
            {
                case ChampionClass.Unknown:
                    return ChampionClassEntity.Unknown;
                case ChampionClass.Assassin:
                    return ChampionClassEntity.Assassin;
                case ChampionClass.Fighter:
                    return ChampionClassEntity.Fighter;
                case ChampionClass.Mage:
                    return ChampionClassEntity.Mage;
                case ChampionClass.Marksman:
                    return ChampionClassEntity.Marksman;
                case ChampionClass.Support:
                    return ChampionClassEntity.Support;
                case ChampionClass.Tank:
                    return ChampionClassEntity.Tank;
                default:
                    return ChampionClassEntity.Unknown;
            }
        }

    }
}
