using System.ComponentModel.DataAnnotations;

namespace MyFlib
{
    public class LargeImageEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string Base64 { get; set; }

    }
}
