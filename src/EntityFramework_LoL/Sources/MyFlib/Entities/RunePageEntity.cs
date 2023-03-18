using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib.Entities
{
    public class RunePageEntity
    {
        [Key]
        [MaxLength(64, ErrorMessage = "the RunePage name must not exceed 64 characters")]
        public string Name { get; set; }

        public ICollection<ChampionEntity> Champions { get; set; }
        public ICollection<DictionaryCategoryRune> DictionaryCategoryRunes { get; set; }


    }
}
