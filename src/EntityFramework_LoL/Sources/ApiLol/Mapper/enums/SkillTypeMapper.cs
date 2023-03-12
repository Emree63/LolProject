using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class SkillTypeMapper
    {
        public static SkillTypeDto ToDto(this SkillType skillType)
        {
            switch (skillType)
            {
                case SkillType.Unknown:
                    return SkillTypeDto.Unknown;
                case SkillType.Basic:
                    return SkillTypeDto.Basic;
                case SkillType.Passive:
                    return SkillTypeDto.Passive;
                case SkillType.Ultimate:
                    return SkillTypeDto.Ultimate;
                default:
                    return SkillTypeDto.Unknown;
            }

        }
        public static SkillType ToModel(this SkillTypeDto skillTypeDto)
        {
            switch (skillTypeDto)
            {
                case SkillTypeDto.Unknown:
                    return SkillType.Unknown;
                case SkillTypeDto.Basic:
                    return SkillType.Basic;
                case SkillTypeDto.Passive:
                    return SkillType.Passive;
                case SkillTypeDto.Ultimate:
                    return SkillType.Ultimate;
                default:
                    return SkillType.Unknown;
            }

        }
    }
}