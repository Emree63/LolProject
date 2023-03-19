using System.ComponentModel.DataAnnotations;

namespace MyFlib.Entities
{
    public class RunePageEntity
    {
        [Key]
        [MaxLength(64, ErrorMessage = "the RunePage name must not exceed 64 characters")]
        public string Name { get; set; }

        public ICollection<ChampionEntity> Champions { get; set; }
        public ICollection<DictionaryCategoryRune> DictionaryCategoryRunes { get; set; }


    }
}
