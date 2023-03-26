using DbManager.Mapper.enums;
using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class SkillMapper
    {
        public static Skill ToModel(this SkillEntity skillEntity) => new(skillEntity.Name, skillEntity.Type.ToModel(), skillEntity.Description);

        public static SkillEntity ToEntity(this Skill skill, ChampionEntity championEntity, LolDbContext context)
        {
            var skillSearch = context.Skills.Find(skill.Name);
            if (skillSearch == null)
            {
                return new()
                {
                    Name = skill.Name,
                    Description = skill.Description,
                    Type = skill.Type.ToEntity(),
                    Champion = championEntity
                };
            }
            throw new Exception("Skill was already exist");
        }

    }
}
