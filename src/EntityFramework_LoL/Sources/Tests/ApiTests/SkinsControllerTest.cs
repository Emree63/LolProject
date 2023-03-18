using ApiLol.Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using StubLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    [TestClass]
    public class SkinsControllerTest
    {
        private readonly StubData stub;
        private readonly SkinsController skins;
        public SkinsControllerTest()
        {
            stub = new StubData();
            skins = new SkinsController(stub, new NullLogger<SkinsController>());
        }

        [TestMethod]
        public async Task TestGetSkins()
        {
            //Arrange

            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skin = await skins.Get(new PageRequest());

            //Assert
            var objectResult = skin as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var skinsResult = objectResult.Value as PageResponse<SkinDtoC>;
            Assert.IsNotNull(skinsResult);

            var result = skinsResult.Data as IEnumerable<SkinDtoC>;
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Count(), total);
            Assert.AreEqual(total, skinsResult.total);

        }

        [TestMethod]
        public async Task TestPostSkin()
        {
            //Arange
            var SkinDto = new SkinDtoC
            {
                Name = "Project Pyke",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 900,
                ChampionName = "Volibear"
            };

            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skinsResult = await skins.Post(SkinDto);

            //Assert
            var objectResult = skinsResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var isSkinDto = objectResult?.Value as SkinDtoC;
            Assert.IsNotNull(isSkinDto);

            Assert.AreEqual(total + 1, await stub.SkinsMgr.GetNbItems());

        }

        [TestMethod]
        public async Task TestCountSkins()
        {
            //Arange
            var SkinDto = new SkinDtoC
            {
                Name = "Project Pyke",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 900,
                ChampionName = "Volibear"
            };

            //Act
            var oldTotal = await stub.SkinsMgr.GetNbItems();
            var oldResult = await skins.GetCountSkins();
            await skins.Post(SkinDto);

            var objectResult = oldResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var newTotal = await stub.SkinsMgr.GetNbItems();
            var newResult = await skins.GetCountSkins();

            //Assert
            var objectResultOld = oldResult as OkObjectResult;
            Assert.IsNotNull(objectResultOld);

            var objectResultNew = newResult as OkObjectResult;
            Assert.IsNotNull(objectResultNew);

            Assert.AreEqual(objectResultOld.Value, oldTotal);
            Assert.AreNotEqual(objectResultOld.Value, newTotal);

            Assert.AreEqual(objectResultNew.Value, newTotal);
            Assert.AreNotEqual(objectResultNew.Value, oldTotal);


        }

        [TestMethod]
        public async Task TestPutSkin()
        {
            //Arange
            var SkinDto = new SkinDtoC
            {
                Name = "Project",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 900,
                ChampionName = "Volibear"
            };
            var SkinDtoPut = new SkinDtoC
            {
                Name = "new Project",
                Description = "ForTestTest",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 850,
                ChampionName = "Volibear"
            };

            //Act
            await skins.Post(SkinDto);
            var skinsResult = await skins.Put(SkinDto.Name, SkinDtoPut);

            //Assert
            var objectResult = skinsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var skin = objectResult?.Value as SkinDtoC;
            Assert.IsNotNull(skin);

            Assert.AreNotEqual(SkinDto.Name, skin.Name);
            Assert.AreNotEqual(SkinDto.Description, skin.Description);
            Assert.AreNotEqual(SkinDto.Price, skin.Price);

            Assert.AreEqual(SkinDtoPut.Name, skin.Name);
            Assert.AreEqual(SkinDtoPut.Description, skin.Description);
            Assert.AreEqual(SkinDtoPut.Price, skin.Price);

        }

        [TestMethod]
        public async Task TestDeleteSkin()
        {
            //Arange


            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skinsResult = await skins.Delete("Project");

            //Assert
            var objectResult = skinsResult as NoContentResult;
            Assert.IsNotNull(objectResult);

            Assert.AreNotEqual(await stub.SkinsMgr.GetNbItems(), total);

        }

    }
}
