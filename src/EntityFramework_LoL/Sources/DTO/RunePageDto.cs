using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class RunePageDto
    {
        public string Name { get; set; }
        public Dictionary<string, RuneDto> Runes { get; set;  }
    }

}
