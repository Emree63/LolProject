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

/*        [TestMethod]
        public async Task TestGetSkins()
        {
            //Arrange

            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skin = await skins.Get(new PageRequest());

            //Assert
            var objectResult = skin as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var skinsResult = objectResult?.Value as IEnumerable<SkinDtoC>;
            Assert.IsNotNull(skinsResult);

            Assert.AreEqual(skinsResult.Count(), total);

        }

        [TestMethod]
        public async Task TestPostSkin()
        {
            //Arange
            var SkinDto = new SkinDtoC
            {
                Name = "Project",
                ChampionName = "Aatrox"
            };

            //Act
            var skinsResult = await skins.Post(SkinDto);

            //Assert
            var objectResult = skinsResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as Ski;
            Assert.IsNotNull(champions);

        }

        [TestMethod]
        public async Task TestPutSkin()
        {
            //Arange
            var ChampionDto = new ChampionDto
            {
                Name = "Sylas",
                Bio = "Good",
                Class = ChampionClassDto.Tank,
                Icon = "",
                Image = new LargeImageDto() { Base64 = "" },
                Skins = new List<SkinDto>()
            };
            var ChampionDtoPut = new ChampionDto
            {
                Name = "Sylas",
                Bio = "Bad",
                Class = ChampionClassDto.Tank,
                Icon = "",
                Image = new LargeImageDto() { Base64 = "" },
                Skins = new List<SkinDto>()
            };

            //Act
            await champs.Post(ChampionDto);
            var championsResult = await champs.Put(ChampionDto.Name, ChampionDtoPut);

            //Assert
            var objectResult = championsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as ChampionDto;
            Assert.IsNotNull(champions);

            Assert.AreNotEqual(ChampionDto.Bio, champions.Bio);
            Assert.AreEqual(ChampionDtoPut.Bio, champions.Bio);

        }

        [TestMethod]
        public async Task TestDeleteChampion()
        {
            //Arange


            //Act
            var total = await stub.ChampionsMgr.GetNbItems();
            var championsResult = await champs.Delete("Akali");

            //Assert
            var objectResult = championsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(objectResult.Value, true);
            Assert.AreNotEqual(await stub.ChampionsMgr.GetNbItems(), total);

        }*/

    }
}
