﻿using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public static class DataSeeder
    {
        public static void SeedData(LolDbContext context)
        {
            var image1 = new LargeImageEntity { Id = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}"), Base64 = "empty" };

            // Champions

            ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity nasus = new ChampionEntity { Name = "Nasus", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity ashe = new ChampionEntity { Name = "Ashe", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };

            context.AddRange(hecarim, nasus, ashe);

            // Skins

            SkinEntity darkJhin = new SkinEntity { Name = "Dark Cosmic Jhin", ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}"), Description = "In the depths of the universe, serial killer Jhin has found a new form of power in cosmic darkness. With his galaxy mask and strange synergy with the four elements of space, he's never been deadlier.", Icon = "empty", Price = 1820, ImageId = Guid.Parse("{7cc1b02d-29a3-4493-96b7-1e3d9f3e14e2}") };
            SkinEntity kaiSaPrestige = new SkinEntity { Name = "K/DA Kai'Sa Prestige Edition", ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}"), Description = "Kai'Sa, the hottest K-pop star of the moment, knows that to make a sensation, you have to be willing to do anything. With her dazzling outfit and electrifying dance moves, she'll make waves on stage and on the battlefield.", Icon = "empty", Price = 2000, ImageId = Guid.Parse("{555c9eb9-f41f-42f1-a05b-ae5d2ee7f782}") };
            SkinEntity pykeProject = new SkinEntity { Name = "PROJECT: Pyke", ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}"), Description = "Pyke, the ultimate android assassin, has recently been upgraded to carry out the most complex missions. With his new tools and enhanced programming, he can sneak into any security system and eliminate any target.", Icon = "empty", Price = 1350, ImageId = Guid.Parse("{6b47024c-0c1d-4066-bda8-2cb0d7c900fa}") };

            context.AddRange(darkJhin, kaiSaPrestige, pykeProject);

            // Skills
            SkillEntity yasuoTempest = new SkillEntity { Name = "Yasuo's Steel Tempest", Description = " une attaque de mêlée qui peut être chargée pour infliger des dégâts supplémentaires et projeter les ennemis dans les airs.", Type = SkillTypeEntity.Basic };
            SkillEntity LuxFinal = new SkillEntity { Name = "Lux's Final Spark", Description = "une attaque à distance qui inflige des dégâts massifs dans une direction.", Type = SkillTypeEntity.Ultimate };

            context.AddRange(yasuoTempest, LuxFinal);

            // Runes

            RuneEntity conqueror = new RuneEntity { Name = "Conqueror", Description = "by dealing damage to an enemy champion, you accumulate stacks that, once fully stacked, increase your damage and provide you with healing.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            RuneEntity ravenousHunter = new RuneEntity { Name = "Ravenous Hunter", Description = "killing minions, monsters, or enemy champions grants you stacks of Ravenous Hunter, which increase your damage against enemy champions and provide you with healing.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };

            context.AddRange(conqueror, ravenousHunter);

            context.SaveChanges();
        }
    }
}
