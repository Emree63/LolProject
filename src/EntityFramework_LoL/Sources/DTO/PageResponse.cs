namespace DTO
{
    public class PageResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int index { get; set; }
        public int count { get; set; }
        public int total { get; set; } 

    }
}
