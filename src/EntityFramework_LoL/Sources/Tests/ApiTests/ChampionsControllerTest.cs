using ApiLol.Controllers;
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
            var champion = await champs.Get(new PageRequest() { index = 0, count = total });

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

    }
}