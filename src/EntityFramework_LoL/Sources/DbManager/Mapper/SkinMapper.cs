using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class SkinMapper
    {
        public static Skin ToModel(this SkinEntity skinEntity)
            => new(skinEntity.Name, skinEntity.Champion.ToModel(), skinEntity.Price, skinEntity.Icon, skinEntity.Image.Base64, skinEntity.Description);

        public static SkinEntity ToEntity(this Skin skin, LolDbContext context)
            => new()
            {
                Name = skin.Name,
                Description = skin.Description,
                Icon = skin.Icon,
                Price = skin.Price,
                Champion = context.Champions.Find(skin.Champion.Name),
                Image = skin.Image.ToEntity()
            };
    }
}
