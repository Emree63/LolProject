using Microsoft.EntityFrameworkCore;
using MyFlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_EF
{
    public class SkillsTest
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Skill_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                SkillEntity fireBall = new SkillEntity { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}") };
                SkillEntity whiteStar = new SkillEntity { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}") };
                SkillEntity yasuoTempest = new SkillEntity { Name = "Yasuo's Steel Tempest", Description = " une attaque de mêlée qui peut être chargée pour infliger des dégâts supplémentaires et projeter les ennemis dans les airs.", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };
                SkillEntity LuxFinal = new SkillEntity { Name = "Lux's Final Spark", Description = "une attaque à distance qui inflige des dégâts massifs dans une direction.", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };

                context.Skills.AddRange(fireBall, whiteStar, yasuoTempest, LuxFinal);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(4, context.Skills.Count());
                Assert.Equal("Boule de feu", context.Skills.First().Name);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Skill_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                SkillEntity fireBall = new SkillEntity { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}") };
                SkillEntity whiteStar = new SkillEntity { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}") };
                SkillEntity yasuoTempest = new SkillEntity { Name = "Yasuo's Steel Tempest", Description = " une attaque de mêlée qui peut être chargée pour infliger des dégâts supplémentaires et projeter les ennemis dans les airs.", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };
                SkillEntity LuxFinal = new SkillEntity { Name = "Lux's Final Spark", Description = "une attaque à distance qui inflige des dégâts massifs dans une direction.", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };

                context.Skills.AddRange(fireBall, whiteStar, yasuoTempest, LuxFinal);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string letterToFind = "a";
                SkillTypeEntity type = SkillTypeEntity.Ultimate;
                Assert.Equal(3, context.Skills.Where(c => c.Description.ToLower().Contains(letterToFind)).Count());
                Assert.Equal(2, context.Skills.Where(c => c.Type == type).Count());
                string descriptionToFind = "random";
                Assert.Equal(1, context.Skills.Where(c => c.Description.ToLower().Contains(descriptionToFind)).Count());
                var ewok = context.Skills.Where(c => c.Description.ToLower().Contains(descriptionToFind)).First();
                ewok.Description = "empty";
                ewok.Type = SkillTypeEntity.Basic;
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string descriptionToFind = "Random";
                Assert.Equal(0, context.Skills.Where(c => c.Description.ToLower().Contains(descriptionToFind)).Count());
                descriptionToFind = "empty";
                SkillTypeEntity type = SkillTypeEntity.Ultimate;
                Assert.Equal(1, context.Skills.Where(c => c.Description.ToLower().Contains(descriptionToFind)).Count());
                Assert.Equal(1, context.Skills.Where(c => c.Type == type).Count());
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_Skill_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                SkillEntity fireBall = new SkillEntity { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}") };
                SkillEntity whiteStar = new SkillEntity { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}") };
                SkillEntity yasuoTempest = new SkillEntity { Name = "Yasuo's Steel Tempest", Description = " une attaque de mêlée qui peut être chargée pour infliger des dégâts supplémentaires et projeter les ennemis dans les airs.", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };
                SkillEntity LuxFinal = new SkillEntity { Name = "Lux's Final Spark", Description = "une attaque à distance qui inflige des dégâts massifs dans une direction.", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}") };

                context.Skills.AddRange(fireBall, whiteStar, yasuoTempest, LuxFinal);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.Skills.First();
                string nameToFind = "boule de feu";
                Assert.Equal(1, context.Skills.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(4, context.Skills.Count());
                context.Skills.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "Boule de feu";
                Assert.Equal(0, context.Skills.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(3, context.Skills.Count());

            }

        }
    }
}
