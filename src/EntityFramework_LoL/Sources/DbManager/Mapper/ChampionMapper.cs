using DbManager.Mapper.enums;
using Model;
using MyFlib;

namespace DbManager.Mapper
{
    public static class ChampionMapper
    {
        public static Champion ToModel(this ChampionEntity championEntity)
        {
            Champion champion = new (championEntity.Name, championEntity.Class.ToModel(), championEntity.Icon, championEntity.Image.Base64, championEntity.Bio);
            foreach (var skill in championEntity.Skills)
            {
                champion.AddSkill(skill.ToModel());
            }
            foreach (var skin in championEntity.Skins)
            {
                champion.AddSkin(new Skin(skin.Name, champion, skin.Price, skin.Icon, skin.Image.Base64, skin.Description));
            }
            if (championEntity.Characteristics != null)
            {
                foreach (var c in championEntity.Characteristics) 
                { 
                    champion.AddCharacteristics(c.ToModel()); 
                }
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
                champ.Skills.Add(skill.ToEntity(champ, context));
            }
            foreach (var skin in champion.Skins)
            {
                champ.Skins.Add(skin.ToEntity(context));
            }
            champ.Characteristics = champion.Characteristics.Select(x => x.ToEntity(champ, context)).ToList();
            return champ;
        }
    }
}
