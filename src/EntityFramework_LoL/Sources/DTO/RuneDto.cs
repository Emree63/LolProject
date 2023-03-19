using DTO.enums;

namespace DTO
{
    public class RuneDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RuneFamilyDto Family { get; set; }
        public string Icon { get; set; }
        public LargeImageDto Image { get; set; }

    }
}
