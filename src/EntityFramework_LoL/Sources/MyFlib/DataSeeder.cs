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
            ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", Image = "" };
            ChampionEntity nasus = new ChampionEntity { Name = "Nasus", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", Image = "" };
            ChampionEntity ashe = new ChampionEntity { Name = "Ashe", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", Image = "" };

            context.AddRange(hecarim, nasus, ashe);

            context.SaveChanges();
        }
    }
}
