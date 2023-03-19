using Microsoft.EntityFrameworkCore;
using MyFlib;
using MyFlib.Entities;
using MyFlib.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_EF
{
    public class RunePagesTest
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_RunePage_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                RuneEntity runeHextech = new RuneEntity { Name = "Hextech Flashtraption ", Description = "While Flash is on cooldown, it is replaced by Hexflash.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RunePageEntity page1 = new RunePageEntity { Name = "Page 1" };
                RunePageEntity page2 = new RunePageEntity { Name = "Page 2" };
                DictionaryCategoryRune dictionary = new DictionaryCategoryRune { category = CategoryEntity.Major, RuneName = runeHextech.Name, RunePageName = page1.Name };

                context.CategoryRunes.Add(dictionary);
                context.RunePages.AddRange(page1, page2);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(2, context.RunePages.Count());
                Assert.Equal("Page 1", context.RunePages.First().Name);
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_RunePage_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                RuneEntity runeHextech = new RuneEntity { Name = "Hextech Flashtraption ", Description = "While Flash is on cooldown, it is replaced by Hexflash.", Family = RuneFamilyEntity.Unknown, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
                RunePageEntity page1 = new RunePageEntity { Name = "Page 1" };
                RunePageEntity page2 = new RunePageEntity { Name = "Page 2" };
                DictionaryCategoryRune dictionary = new DictionaryCategoryRune { category = CategoryEntity.Major, RuneName = runeHextech.Name, RunePageName = page1.Name };

                context.CategoryRunes.Add(dictionary);
                context.RunePages.AddRange(page1, page2);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.RunePages.First();
                string nameToFind = "1";
                Assert.Equal(1, context.RunePages.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(2, context.RunePages.Count());
                context.RunePages.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string nameToFind = "1";
                Assert.Equal(0, context.RunePages.Where(c => c.Name.ToLower().Contains(nameToFind)).Count());
                Assert.Equal(1, context.RunePages.Count());

            }

        }
    }
}
