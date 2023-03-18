using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib.Entities
{
    public class CharacteristicEntity
    {
        [Key]
        [MaxLength(254)]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public Guid ChampionForeignKey { get; set; }

        [ForeignKey("ChampionForeignKey")]
        public ChampionEntity Champion { get; set; }
    }
}
