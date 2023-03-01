using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public static class DataSeeder
    {
        public static void SeedData(LolDbContext context)
        {
            var image1 = new LargeImageEntity { Id = 1, Base64 = "empty" };

            ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity nasus = new ChampionEntity { Name = "Nasus", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity ashe = new ChampionEntity { Name = "Ashe", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", ImageId = 1 };

            context.AddRange(hecarim, nasus, ashe);

            context.SaveChanges();
        }
    }
}
