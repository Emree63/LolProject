using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SkillDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SkillTypeDto Type { get; set; }
    }
}
