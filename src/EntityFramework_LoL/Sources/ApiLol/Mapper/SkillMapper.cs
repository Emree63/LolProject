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
            };
        }

/*        public static Skill ToModel(this SkillDto skillDto)
        {
            return new Skill(skill.Name)
            {
                Description = skill.Description
            };
        }*/
    }
}
