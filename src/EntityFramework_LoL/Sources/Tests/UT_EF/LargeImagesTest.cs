using Microsoft.EntityFrameworkCore;
using MyFlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_EF
{
    public class LargeImagesTest
    {
        [Fact]
        public void TestAdd()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_LargeImage_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                LargeImageEntity image1 = new LargeImageEntity { Id = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}"), Base64 = "https://fastly.picsum.photos/id/598/2000/2000.jpg?hmac=MReozmZFar5xI7HICmcgvZTP739rBonuoAmpBWE-4XE" };
                LargeImageEntity image2 = new LargeImageEntity { Id = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}"), Base64 = "https://fastly.picsum.photos/id/788/2000/2000.jpg?hmac=UKqhiA0k3uH3wqqaIYk-o18U1kNPnD_MVq7fLdtW1R8" };

                context.LargeImages.AddRange(image1, image2);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                Assert.Equal(2, context.LargeImages.Count());
                Assert.Equal("https://fastly.picsum.photos/id/598/2000/2000.jpg?hmac=MReozmZFar5xI7HICmcgvZTP739rBonuoAmpBWE-4XE", context.LargeImages.First().Base64);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_LargeImage_database")
                .Options;

            using (var context = new LolDbContext(options))
            {
                LargeImageEntity image1 = new LargeImageEntity { Id = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}"), Base64 = "https://fastly.picsum.photos/id/598/2000/2000.jpg?hmac=MReozmZFar5xI7HICmcgvZTP739rBonuoAmpBWE-4XE" };
                LargeImageEntity image2 = new LargeImageEntity { Id = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}"), Base64 = "https://fastly.picsum.photos/id/788/2000/2000.jpg?hmac=UKqhiA0k3uH3wqqaIYk-o18U1kNPnD_MVq7fLdtW1R8" };

                context.LargeImages.AddRange(image1, image2);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string linkToFind = "fastly";
                Assert.Equal(2, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
                linkToFind = "bonuoampbwe";
                Assert.Equal(1, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
                var ewok = context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).First();
                ewok.Base64 = "empty";
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                string linkToFind = "bonuoampbwe";
                Assert.Equal(0, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
                linkToFind = "empty";
                Assert.Equal(1, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
            }
        }

        [Fact]
        public void Delete_Test()
        {
            var options = new DbContextOptionsBuilder<LolDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Test_LargeImage_database")
                .Options;

            using (var context = new LolDbContext(options))
            {

                LargeImageEntity image1 = new LargeImageEntity { Id = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}"), Base64 = "https://fastly.picsum.photos/id/598/2000/2000.jpg?hmac=MReozmZFar5xI7HICmcgvZTP739rBonuoAmpBWE-4XE" };
                LargeImageEntity image2 = new LargeImageEntity { Id = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}"), Base64 = "https://fastly.picsum.photos/id/788/2000/2000.jpg?hmac=UKqhiA0k3uH3wqqaIYk-o18U1kNPnD_MVq7fLdtW1R8" };

                context.LargeImages.AddRange(image1, image2);
                context.SaveChanges();
            }

            using (var context = new LolDbContext(options))
            {
                var ewok = context.LargeImages.First();
                string linkToFind = "bonuoampbwe";
                Assert.Equal(1, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
                Assert.Equal(2, context.LargeImages.Count());
                context.LargeImages.Remove(ewok);
                context.SaveChanges();

            }

            using (var context = new LolDbContext(options))
            {
                string linkToFind = "bonuoampbwe";
                Assert.Equal(0, context.LargeImages.Where(c => c.Base64.ToLower().Contains(linkToFind)).Count());
                Assert.Equal(1, context.LargeImages.Count());

            }

        }
    }
}
