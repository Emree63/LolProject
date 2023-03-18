using MyFlib.Entities;
using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class DictionaryCategoryRune
    {
        public CategoryEntity category { get; set; }

        [ForeignKey("RunePageName")]
        public RunePageEntity runePage { get; set; }
        public string RunePageName { get; set; }

        [ForeignKey("RuneName")]
        public RuneEntity rune { get; set; }
        public string RuneName { get; set; }

    }
}
