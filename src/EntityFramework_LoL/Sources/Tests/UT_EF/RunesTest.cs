using Microsoft.EntityFrameworkCore;
using MyFlib;
using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_EF
{
    public class RunesTest
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Rune_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                RuneEntity conqueror = new RuneEntity { Name = "Conqueror", Description = "by dealing damage to an enemy champion, you accumulate stacks that, once fully stacked, increase your damage and provide you with healing.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity ravenousHunter = new RuneEntity { Name = "Ravenous Hunter", Description = "killing minions, monsters, or enemy champions grants you stacks of Ravenous Hunter, which increase your damage against enemy champions and provide you with healing.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity electrocute = new RuneEntity { Name = "Electrocute", Description = "hitting an enemy champion with 3 separate attacks or abilities within 3 seconds deals bonus damage.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{e7c87f12-2c7b-44d5-8867-eba1ae5a4657}") };
                RuneEntity pressTheAttack = new RuneEntity { Name = "Press the Attack", Description = "hitting an enemy champion with 3 consecutive basic attacks deals bonus damage and makes them take increased damage from all sources for a short period of time.", Family = RuneFamilyEntity.Precision, ImageId = Guid.Parse("{7c354729-5ecf-43d8-ae73-153740e87644}") };

                context.Runes.AddRange(conqueror, ravenousHunter, electrocute, pressTheAttack);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(4, context.Runes.Count());
                Assert.Equal("Conqueror", context.Runes.First().Name);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Rune_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                RuneEntity conqueror = new RuneEntity { Name = "Conqueror", Description = "by dealing damage to an enemy champion, you accumulate stacks that, once fully stacked, increase your damage and provide you with healing.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity ravenousHunter = new RuneEntity { Name = "Ravenous Hunter", Description = "killing minions, monsters, or enemy champions grants you stacks of Ravenous Hunter, which increase your damage against enemy champions and provide you with healing.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity electrocute = new RuneEntity { Name = "Electrocute", Description = "hitting an enemy champion with 3 separate attacks or abilities within 3 seconds deals bonus damage.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{e7c87f12-2c7b-44d5-8867-eba1ae5a4657}") };
                RuneEntity pressTheAttack = new RuneEntity { Name = "Press the Attack", Description = "hitting an enemy champion with 3 consecutive basic attacks deals bonus damage and makes them take increased damage from all sources for a short period of time.", Family = RuneFamilyEntity.Precision, ImageId = Guid.Parse("{7c354729-5ecf-43d8-ae73-153740e87644}") };

                context.Runes.AddRange(conqueror, ravenousHunter, electrocute, pressTheAttack);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string bioToFind = "stacks";
                RuneFamilyEntity type = RuneFamilyEntity.Domination;
                Assert.Equal(2, context.Runes.Where(c => c.Description.ToLower().Contains(bioToFind)).Count());
                Assert.Equal(2, context.Runes.Where(c => c.Family == type).Count());
                bioToFind = "dealing damage";
                Assert.Equal(1, context.Runes.Where(c => c.Description.ToLower().Contains(bioToFind)).Count());
                var ewok = context.Runes.Where(c => c.Description.ToLower().Contains(bioToFind)).First();
                ewok.Description = "Rune resist";
                ewok.Family = type;
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string bioToFind = "stacks";
                Assert.Equal(1, context.Runes.Where(c => c.Description.ToLower().Contains(bioToFind)).Count());
                bioToFind = "rune resist";
                RuneFamilyEntity type = RuneFamilyEntity.Domination;
                Assert.Equal(1, context.Runes.Where(c => c.Description.ToLower().Contains(bioToFind)).Count());
                Assert.Equal(3, context.Runes.Where(c => c.Family == type).Count());
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_Rune_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                RuneEntity conqueror = new RuneEntity { Name = "Conqueror", Description = "by dealing damage to an enemy champion, you accumulate stacks that, once fully stacked, increase your damage and provide you with healing.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity ravenousHunter = new RuneEntity { Name = "Ravenous Hunter", Description = "killing minions, monsters, or enemy champions grants you stacks of Ravenous Hunter, which increase your damage against enemy champions and provide you with healing.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RuneEntity electrocute = new RuneEntity { Name = "Electrocute", Description = "hitting an enemy champion with 3 separate attacks or abilities within 3 seconds deals bonus damage.", Family = RuneFamilyEntity.Domination, ImageId = Guid.Parse("{e7c87f12-2c7b-44d5-8867-eba1ae5a4657}") };
                RuneEntity pressTheAttack = new RuneEntity { Name = "Press the Attack", Description = "hitting an enemy champion with 3 consecutive basic attacks deals bonus damage and makes them take increased damage from all sources for a short period of time.", Family = RuneFamilyEntity.Precision, ImageId = Guid.Parse("{7c354729-5ecf-43d8-ae73-153740e87644}") };

                context.Runes.AddRange(conqueror, ravenousHunter, electrocute, pressTheAttack);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.Runes.First();
                string nameToFind = "conqueror";
                Assert.Equal(1, context.Runes.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(4, context.Runes.Count());
                context.Runes.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "conqueror";
                Assert.Equal(0, context.Runes.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(3, context.Runes.Count());

            }

        }
    }
}
