using DbManager.Mapper.enums;
using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class SkillMapper
    {
        public static Skill ToModel(this SkillEntity skillEntity) => new(skillEntity.Name, skillEntity.Type.ToModel(), skillEntity.Description);


        public static SkillEntity ToEntity(this Skill skill, ChampionEntity championEntity)
        {
            return new()
            {
                Name = skill.Name,
                Description = skill.Description,
                Type = skill.Type.ToEntity(),
                Champion = championEntity
            };
        }

    }
}
