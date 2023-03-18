using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class SkinEntity
    {
        [Key]
        [MaxLength(254, ErrorMessage = "the Skin name must not exceed 254 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        [ForeignKey("ChampionForeignKey")]
        public ChampionEntity Champion { get; set; }
        public Guid ChampionForeignKey { get; set; }
        public LargeImageEntity Image { get; set; }
        [ForeignKey("Image")]
        public Guid ImageId { get; set; }

    }
}
