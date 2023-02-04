
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
                ChampionEntity sylas = new ChampionEntity { Name = "Sylas", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", Image = "" };
                ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", Image = "" };
                ChampionEntity yuumi = new ChampionEntity { Name = "yuumi", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", Image = "" };

                context.Champions.Add(sylas);
                context.Champions.Add(hecarim);
                context.Champions.Add(yuumi);
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
                ChampionEntity sylas = new ChampionEntity { Name = "Sylas", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", Image = "" };
                ChampionEntity hecarim = new ChampionEntity { Name = "Hecarim", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", Image = "" };
                ChampionEntity yuumi = new ChampionEntity { Name = "yuumi", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", Image = "" };

                context.Champions.Add(sylas);
                context.Champions.Add(hecarim);
                context.Champions.Add(yuumi);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "m";
                Assert.Equal(2, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "yuu";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                var ewok = context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).First();
                ewok.Name = "Garen";
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "m";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "garen";
                Assert.Equal(1, context.Champions.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
            }
        }
    }
}