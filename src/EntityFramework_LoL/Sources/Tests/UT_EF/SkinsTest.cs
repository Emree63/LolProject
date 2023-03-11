using Microsoft.EntityFrameworkCore;
using MyFlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_EF
{
    public class SkinsTest
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Skin_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                SkinEntity darkJhin = new SkinEntity { Name = "Dark Cosmic Jhin", ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}"), Description = "In the depths of the universe, serial killer Jhin has found a new form of power in cosmic darkness. With his galaxy mask and strange synergy with the four elements of space, he's never been deadlier.", Icon = "empty", Price = 1820, ImageId = Guid.Parse("{7cc1b02d-29a3-4493-96b7-1e3d9f3e14e2}") };
                SkinEntity kaiSaPrestige = new SkinEntity { Name = "K/DA Kai'Sa Prestige Edition", ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}"), Description = "Kai'Sa, the hottest K-pop star of the moment, knows that to make a sensation, you have to be willing to do anything. With her dazzling outfit and electrifying dance moves, she'll make waves on stage and on the battlefield.", Icon = "empty", Price = 2000, ImageId = Guid.Parse("{555c9eb9-f41f-42f1-a05b-ae5d2ee7f782}") };
                SkinEntity pykeProject = new SkinEntity { Name = "PROJECT: Pyke", ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}"), Description = "Pyke, the ultimate android assassin, has recently been upgraded to carry out the most complex missions. With his new tools and enhanced programming, he can sneak into any security system and eliminate any target.", Icon = "empty", Price = 1350, ImageId = Guid.Parse("{6b47024c-0c1d-4066-bda8-2cb0d7c900fa}") };

                context.Skins.AddRange(darkJhin, kaiSaPrestige, pykeProject);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(3, context.Skins.Count());
                Assert.Equal("Dark Cosmic Jhin", context.Skins.First().Name);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Skin_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                SkinEntity darkJhin = new SkinEntity { Name = "Dark Cosmic Jhin", ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}"), Description = "In the depths of the universe, serial killer Jhin has found a new form of power in cosmic darkness. With his galaxy mask and strange synergy with the four elements of space, he's never been deadlier.", Icon = "empty", Price = 1820, ImageId = Guid.Parse("{7cc1b02d-29a3-4493-96b7-1e3d9f3e14e2}") };
                SkinEntity kaiSaPrestige = new SkinEntity { Name = "K/DA Kai'Sa Prestige Edition", ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}"), Description = "Kai'Sa, the hottest K-pop star of the moment, knows that to make a sensation, you have to be willing to do anything. With her dazzling outfit and electrifying dance moves, she'll make waves on stage and on the battlefield.", Icon = "empty", Price = 2000, ImageId = Guid.Parse("{555c9eb9-f41f-42f1-a05b-ae5d2ee7f782}") };
                SkinEntity pykeProject = new SkinEntity { Name = "PROJECT: Pyke", ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}"), Description = "Pyke, the ultimate android assassin, has recently been upgraded to carry out the most complex missions. With his new tools and enhanced programming, he can sneak into any security system and eliminate any target.", Icon = "empty", Price = 1350, ImageId = Guid.Parse("{6b47024c-0c1d-4066-bda8-2cb0d7c900fa}") };

                context.Skins.AddRange(darkJhin, kaiSaPrestige, pykeProject);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string letterToFind = "i";
                Assert.Equal(3, context.Skins.Where(c => c.Description.ToLower().Contains(letterToFind)).Count());
                letterToFind = "depths";
                Assert.Equal(1, context.Skins.Where(c => c.Description.ToLower().Contains(letterToFind)).Count());
                var ewok = context.Skins.Where(c => c.Description.ToLower().Contains(letterToFind)).First();
                ewok.Description = "For test";
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "depths";
                Assert.Equal(0, context.Skins.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                string descriptionToFind = "for test";
                Assert.Equal(1, context.Skins.Where(c => c.Description.ToLower().Contains(descriptionToFind)).Count());
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_Skin_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                SkinEntity darkJhin = new SkinEntity { Name = "Dark Cosmic Jhin", ChampionForeignKey = Guid.Parse("{234F5E7F-F196-4C88-AD1C-6C392AA2E038}"), Description = "In the depths of the universe, serial killer Jhin has found a new form of power in cosmic darkness. With his galaxy mask and strange synergy with the four elements of space, he's never been deadlier.", Icon = "empty", Price = 1820, ImageId = Guid.Parse("{7cc1b02d-29a3-4493-96b7-1e3d9f3e14e2}") };
                SkinEntity kaiSaPrestige = new SkinEntity { Name = "K/DA Kai'Sa Prestige Edition", ChampionForeignKey = Guid.Parse("{15E0C4F4-4C04-4CCE-8F4D-78F37F63E63F}"), Description = "Kai'Sa, the hottest K-pop star of the moment, knows that to make a sensation, you have to be willing to do anything. With her dazzling outfit and electrifying dance moves, she'll make waves on stage and on the battlefield.", Icon = "empty", Price = 2000, ImageId = Guid.Parse("{555c9eb9-f41f-42f1-a05b-ae5d2ee7f782}") };
                SkinEntity pykeProject = new SkinEntity { Name = "PROJECT: Pyke", ChampionForeignKey = Guid.Parse("{F32FA768-A1DC-4F6A-9366-FFEC6B0D4159}"), Description = "Pyke, the ultimate android assassin, has recently been upgraded to carry out the most complex missions. With his new tools and enhanced programming, he can sneak into any security system and eliminate any target.", Icon = "empty", Price = 1350, ImageId = Guid.Parse("{6b47024c-0c1d-4066-bda8-2cb0d7c900fa}") };

                context.Skins.AddRange(darkJhin, kaiSaPrestige, pykeProject);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.Skins.First();
                string nameToFind = "jhin";
                Assert.Equal(1, context.Skins.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(3, context.Skins.Count());
                context.Skins.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "jhin";
                Assert.Equal(0, context.Skins.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(2, context.Skins.Count());

            }

        }
    }
}

