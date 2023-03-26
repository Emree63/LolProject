using DbManager.Mapper.enums;
using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class RuneMapper
    {
        public static Rune ToModel(this RuneEntity rune) => new(rune.Name, rune.Family.ToModel(), rune.Icon, "", rune.Description);
        public static RuneEntity ToEntity(this Rune rune)
            => new()
            {
                Name = rune.Name,
                Description = rune.Description,
                Family = rune.Family.ToEntity(),
                Icon = rune.Icon,
                Image = rune.Image.ToEntity()
            };

    }
}
