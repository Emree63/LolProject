using Microsoft.EntityFrameworkCore;
using MyFlib;
using Xunit;

namespace UT_EF
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                ChampionEntity sylas = new ChampionEntity { Name = "Sylas", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity yuumi = new ChampionEntity { Name = "yuumi", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", ImageId = 1 };
                
                // test contrainte 
                ChampionEntity errorName = new ChampionEntity
                {
                    Name = "c1832f35-f909-422d-a1fb-e0b79a62f562-fa7c5fe2-89b7-432e-9e0f-a5736445b381-3f75c0f8-de2e-4cf4-82d2-3d24411f6422-6b7e9196-3664-4813-b971-e9cc08a4b255-c1832f35-f909-422d-a1fb-e0b79a62f562-fa7c5fe2-89b7-432e-9e0f-a5736445b381-3f75c0f8-de2e-4cf4-82d2-3d24411f6422-6b7e9196-3664-4813-b971-e9cc08a4b255",
                    Class = ChampionClassEntity.Mage,
                    Bio = "",
                    Icon = "",
                    ImageId = 1
                };
                context.Champions.AddRange(sylas, hecarim, yuumi);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(3, context.Champions.Count());
                Assert.Equal("Sylas", context.Champions.First().Name);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                ChampionEntity sylas = new ChampionEntity { Name = "Sylas", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity yuumi = new ChampionEntity { Name = "yuumi", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", ImageId = 1 };

                context.Champions.AddRange(sylas, hecarim, yuumi);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "m";
                ChampionClassEntity type = ChampionClassEntity.Fighter;
                Assert.Equal(2, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(1, context.Champions.Where(c => c.Class == type).Count());
                nameToFind = "yuu";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                var ewok = context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).First();
                ewok.Name = "Garen";
                ewok.Bio = "Magic resist";
                ewok.Class = type;
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "m";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "garen";
                string bioToFind = "magic resist";
                ChampionClassEntity type = ChampionClassEntity.Fighter;
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(1, context.Champions.Where(c => c.Bio.ToLower().Contains(bioToFind)).Count());
                Assert.Equal(2, context.Champions.Where(c => c.Class == type).Count());
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                ChampionEntity sylas = new ChampionEntity { Name = "Sylas", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", ImageId = 1 };
                ChampionEntity yuumi = new ChampionEntity { Name = "yuumi", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", ImageId = 1 };

                context.Champions.AddRange(sylas, hecarim, yuumi);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.Champions.First();
                string nameToFind = "sylas";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(3, context.Champions.Count());
                context.Champions.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "sylas";
                Assert.Equal(0, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(2, context.Champions.Count());

            }

        }
    }
}