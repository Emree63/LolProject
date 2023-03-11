using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class SkillEntity
    {
        [Key]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public SkillTypeEntity Type { get; set; }

    }
}
