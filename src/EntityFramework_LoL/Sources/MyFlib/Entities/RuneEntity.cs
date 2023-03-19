using MyFlib.Entities.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlib
{
    public class RuneEntity
    {
        [Key]
        [MaxLength(64, ErrorMessage = "the Rune name must not exceed 64 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public RuneFamilyEntity Family { get; set; }
        public ICollection<DictionaryCategoryRune> DictionaryCategoryRunes { get; set; }
        public string Icon { get; set; }
        public LargeImageEntity Image { get; set; }

        [ForeignKey("Image")]
        public Guid ImageId { get; set; }
    }
}
