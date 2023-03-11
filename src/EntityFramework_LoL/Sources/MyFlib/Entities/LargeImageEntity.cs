using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class LargeImageEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string Base64 { get; set; }

    }
}
