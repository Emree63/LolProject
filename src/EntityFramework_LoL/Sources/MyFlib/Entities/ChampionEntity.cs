using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class ChampionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Bio { get; set; }
        public string Icon { get; set; }
        [Required]
        public ChampionClassEntity Class { get; set; }
        public ICollection<SkillEntity> Skills { get; set; }
        public ICollection<SkinEntity> Skins { get; set; }

        public LargeImageEntity Image { get; set; }

        [ForeignKey("Image")]
        public int ImageId { get; set; }

    }
}
