using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class SkinEntity
    {
        [Key]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public float Price { get; set; }
        public LargeImageEntity Image { get; set; }

    }
}
