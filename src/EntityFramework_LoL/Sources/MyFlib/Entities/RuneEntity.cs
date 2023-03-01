using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class RuneEntity
    {
        [Key]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public SkillTypeEntity SkillType { get; set; }
        public LargeImageEntity Image { get; set; }

        [ForeignKey("Image")]
        public int ImageId { get; set; }
    }
}
