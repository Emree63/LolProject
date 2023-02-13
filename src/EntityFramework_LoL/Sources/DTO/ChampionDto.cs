namespace DTO
{
    public class ChampionDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public ChampionClassDto Class { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public IEnumerable<SkinDto> Skins { get; set; }

    }
}