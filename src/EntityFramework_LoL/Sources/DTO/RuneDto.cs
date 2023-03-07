using DTO.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RuneDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RuneFamilyDto Family { get; set; }
        public LargeImageDto Image { get; set; }

    }
}
