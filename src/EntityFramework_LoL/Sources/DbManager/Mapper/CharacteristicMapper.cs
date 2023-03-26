using MyFlib.Entities;
using MyFlib;

namespace DbManager.Mapper
{
    public static class CharacteristicMapper
    {
        public static CharacteristicEntity ToEntity(this KeyValuePair<string, int> item, ChampionEntity champion, LolDbContext context)
        {
            var characteristicEntity = context.Characteristic.Find(item.Key, champion.Id);
            if (characteristicEntity == null)
            {
                return new()
                {
                    Name = item.Key,
                    Value = item.Value,
                    ChampionForeignKey = champion.Id
                };
            }
            return characteristicEntity;
        }


        public static Tuple<string, int> ToModel(this CharacteristicEntity entity)
            => new(entity.Name, entity.Value);
    }
}
