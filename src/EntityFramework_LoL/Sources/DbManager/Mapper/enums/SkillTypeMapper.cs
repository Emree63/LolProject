using Model;
using MyFlib;

namespace DbManager.Mapper.enums
{
    public static class SkillTypeMapper
    {
        public static SkillType ToModel(this SkillTypeEntity skillTypeEntity)
        {
            switch (skillTypeEntity)
            {
                case SkillTypeEntity.Unknown:
                    return SkillType.Unknown;
                case SkillTypeEntity.Basic:
                    return SkillType.Basic;
                case SkillTypeEntity.Passive:
                    return SkillType.Passive;
                case SkillTypeEntity.Ultimate:
                    return SkillType.Ultimate;
                default:
                    return SkillType.Unknown;
            }
        }
        public static SkillTypeEntity ToEntity(this SkillType skillType)
        {
            switch (skillType)
            {
                case SkillType.Unknown:
                    return SkillTypeEntity.Unknown;
                case SkillType.Basic:
                    return SkillTypeEntity.Basic;
                case SkillType.Passive:
                    return SkillTypeEntity.Passive;
                case SkillType.Ultimate:
                    return SkillTypeEntity.Ultimate;
                default:
                    return SkillTypeEntity.Unknown;
            }

        }
    }
}
