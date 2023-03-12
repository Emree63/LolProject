using ApiLol.Controllers;
using ApiLol.Controllers.v2;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StubLib;

namespace ApiTests
{
    [TestClass]
    public class ChampionsControllerTest
    {
        private readonly StubData stub;
        private readonly ChampionsController champs;
        public ChampionsControllerTest()
        {
            stub = new StubData();
            champs = new ChampionsController(stub, new NullLogger<ChampionsController>());
        }

        [TestMethod]
        public async Task TestGetChampions()
        {
            //Arrange

            //Act
            var total = await stub.ChampionsMgr.GetNbItems();
            var champion = await champs.Get(new PageRequest());

            //Assert
            var objectResult = champion as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as IEnumerable<ChampionDto>;
            Assert.IsNotNull(champions);

            Assert.AreEqual(champions.Count(), total);

        }

        [TestMethod]
        public async Task TestPostChampion()
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

            //Act
            var championsResult = await champs.Post(ChampionDto);

            //Assert
            var objectResult = championsResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as ChampionDto;
            Assert.IsNotNull(champions);

        }

        [TestMethod]
        public async Task TestPutChampion()
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

        }

    }
}