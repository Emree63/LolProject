using DTO;
using DTO.enums;
using Model;

namespace ApiLol.Mapper.enums
{
    public static class SkillTypeMapper
    {
        public static SkillTypeDto ToDto(this SkillType skillType)
        {
            if (skillType == SkillType.Unknown)
            {
                return SkillTypeDto.Unknown;
            }
            if (skillType == SkillType.Basic)
            {
                return SkillTypeDto.Basic;
            }
            if (skillType == SkillType.Passive)
            {
                return SkillTypeDto.Passive;
            }
            if (skillType == SkillType.Ultimate)
            {
                return SkillTypeDto.Ultimate;
            }
            else
            {
                return SkillTypeDto.Unknown;
            }

        }
        public static SkillType ToModel(this SkillTypeDto skillTypeDto)
        {
            if (skillTypeDto == SkillTypeDto.Unknown)
            {
                return SkillType.Unknown;
            }
            if (skillTypeDto == SkillTypeDto.Basic)
            {
                return SkillType.Basic;
            }
            if (skillTypeDto == SkillTypeDto.Passive)
            {
                return SkillType.Passive;
            }
            if (skillTypeDto == SkillTypeDto.Ultimate)
            {
                return SkillType.Ultimate;
            }
            else
            {
                return SkillType.Unknown;
            }

        }
    }
}