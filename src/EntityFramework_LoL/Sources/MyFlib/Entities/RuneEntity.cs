﻿using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class RuneEntity
    {
        [Key]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public RuneFamilyEntity Family { get; set; }
        public LargeImageEntity Image { get; set; }

        [ForeignKey("Image")]
        public Guid ImageId { get; set; }
    }
}