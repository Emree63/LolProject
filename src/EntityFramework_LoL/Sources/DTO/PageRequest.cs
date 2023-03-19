namespace DTO
{
    public class PageRequest
    {
        public int index { get; set; } = 0;
        public int count { get; set; } = 0;
        public string? name { get; set; } = null;
        public string? orderingPropertyName { get; set; } = "Name";
        public bool descending { get; set; } = false;
    }
}
