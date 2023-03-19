using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlib
{
    public class SkillEntity
    {
        [Key]
        [MaxLength(64, ErrorMessage = "the Skill name must not exceed 64 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public SkillTypeEntity Type { get; set; }

        [Required]
        [ForeignKey("ChampionForeignKey")]
        public ChampionEntity Champion { get; set; }
        public Guid ChampionForeignKey { get; set; }

    }
}
