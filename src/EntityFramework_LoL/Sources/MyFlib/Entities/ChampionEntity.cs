using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class ChampionEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Bio { get; set; }
        [MaxLength(255)]
        public string Icon { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
        public ChampionClassEntity Class { get; set; }

    }
}
