using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class SkinMapper
    {
        public static Skin ToModel(this SkinEntity skinEntity)
            => new(skinEntity.Name, skinEntity.Champion.ToModel(), skinEntity.Price, skinEntity.Icon, skinEntity.Image.Base64, skinEntity.Description);

        public static SkinEntity ToEntity(this Skin skin, LolDbContext context)
        {
            var skinSearch = context.Skins.Find(skin.Name);
            if(skinSearch == null)
            {
                return new()
                {
                    Name = skin.Name,
                    Description = skin.Description,
                    Icon = skin.Icon,
                    Price = skin.Price,
                    Champion = context.Champions.FirstOrDefault(c => c.Name == skin.Champion.Name),
                    Image = skin.Image.ToEntity()
                };
            }
            throw new Exception("Skin was already exist");
        }
    }
}
