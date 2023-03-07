using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PageRequest
    {
        public int index { get; set; } = 0;
        public int count { get; set; } = 0;
        public string? orderingPropertyName { get; set; } = "Name";
        public bool descending { get; set; } = false;
    }
}
