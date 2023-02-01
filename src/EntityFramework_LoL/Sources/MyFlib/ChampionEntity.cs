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
        public string Name { get; set; }
        public ChampionEntity(string name)
        {
            Name = name;
        }
    }
}
