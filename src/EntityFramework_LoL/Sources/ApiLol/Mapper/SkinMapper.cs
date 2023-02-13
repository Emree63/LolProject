using DTO;

namespace ApiLol.Mapper
{
    public static class SkinMapper
    {
        public static SkinDto ToDto(this SkinDto skin)
        {
            return new SkinDto()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Price = skin.Price
            };
        }
    }
}
