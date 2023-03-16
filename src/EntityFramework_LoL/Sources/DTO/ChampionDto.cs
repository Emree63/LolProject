namespace DTO
{
    public class ChampionDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public ChampionClassDto Class { get; set; }
        public string Icon { get; set; }
        public LargeImageDto Image { get; set; }
        public IEnumerable<SkinDto>? Skins { get; set; }
        public IEnumerable<SkillDto>? Skills { get; set; }
        public Dictionary<string, int>? Characteristics { get; set; }

    }
}