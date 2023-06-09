﻿using ApiMapping;
using ApiMapping.enums;
using DTO;
using Model;

namespace ApiMapping
{
    public static class SkillMapper
    {
        public static SkillDto ToDto(this Skill skill)
            => new()
            {
                Name = skill.Name,
                Description = skill.Description,
                Type = skill.Type.ToDto()
            };

        public static Skill ToModel(this SkillDto skillDto) => new(skillDto.Name, skillDto.Type.ToModel(), skillDto.Description);

    }
}
