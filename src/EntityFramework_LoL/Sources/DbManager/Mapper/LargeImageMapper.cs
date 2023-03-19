using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class LargeImageMapper
    {
        public static LargeImage ToModel(this LargeImageEntity largeImage) => new(largeImage.Base64);

        public static LargeImageEntity ToEntity(this LargeImage largeImage) => new() { Base64 = largeImage.Base64 };

    }
}
