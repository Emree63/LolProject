using DbManager.Mapper.enums;
using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class ChampionMapper
    {
        public static Champion ToModel(this ChampionEntity championEntity)
        {
            Champion champion = new (championEntity.Name, championEntity.Class.ToModel(), championEntity.Icon, "", championEntity.Bio);
            foreach (var skill in championEntity.Skills)
            {
                champion.AddSkill(skill.ToModel());
            }
            foreach (var skin in championEntity.Skins)
            {
                champion.AddSkin(skin.ToModel());
            }
            return champion;
        }

        public static ChampionEntity ToEntity(this Champion champion, LolDbContext context)
        {
            var champ = new ChampionEntity()
            {
                Name = champion.Name,
                Icon = champion.Icon,
                Bio = champion.Bio,
                Image = champion.Image.ToEntity(),
            };
            foreach (var skill in champion.Skills)
            {
                champ.Skills.Add(skill.ToEntity(champ));
            }
            foreach (var skin in champion.Skins)
            {
                champ.Skins.Add(skin.ToEntity(context));
            }
            return champ;
        }
    }
}
