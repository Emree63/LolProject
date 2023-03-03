using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class SkillMapper
    {
        public static SkillDto ToDto(this Skill skill)
        {
            return new SkillDto()
            {
                Name = skill.Name,
                Description = skill.Description,
                Type = skill.Type.ToDto()
            };
        }

        public static Skill ToModel(this SkillDto skillDto)
        {
            return new Skill(skillDto.Name, skillDto.Type.ToModel(), skillDto.Description);
        }
    }
}
