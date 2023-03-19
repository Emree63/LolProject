using MyFlib.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlib
{
    public class ChampionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "the champion name must not exceed 64 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Bio { get; set; }
        public string Icon { get; set; }
        [Required]
        public ChampionClassEntity Class { get; set; }
        public ICollection<SkillEntity> Skills { get; set; } = new List<SkillEntity>();
        public ICollection<SkinEntity> Skins { get; set; } = new List<SkinEntity>();
        public ICollection<CharacteristicEntity> Characteristics { get; set; }
        public ICollection<RunePageEntity> RunePages { get; set; } = new List<RunePageEntity>();
        public LargeImageEntity Image { get; set; }

        [ForeignKey("Image")]
        public Guid ImageId { get; set; }

    }
}
