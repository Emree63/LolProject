using DTO;
using Model;

namespace ApiLol.Mapper
{
    public static class LargeImageMapper
    {
        public static LargeImageDto ToDto(this LargeImage largeImage)
        {
            return new LargeImageDto()
            {
                Base64 = largeImage.Base64
            };
        }

        public static LargeImage ToModel(this LargeImageDto largeImageDto)
        {
            return new LargeImage(largeImageDto.Base64);
        }
    }
}