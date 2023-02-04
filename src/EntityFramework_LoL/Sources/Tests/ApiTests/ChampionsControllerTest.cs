using ApiLol.Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
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
            champs = new ChampionsController(stub);
        }

        [TestMethod]
        public async Task TestGetChampions()
        {
            //Arrange

            //Act
            var champion = await champs.Get();

            //Assert
            var objectResult = champion as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as IEnumerable<ChampionDto>;
            Assert.IsNotNull(champions);

            Assert.AreEqual(champions.Count(), await stub.ChampionsMgr.GetNbItems());

        }

        [TestMethod]
        public async Task TestPostChampion()
        {
            //Arange
            var ChampionDto = new ChampionDto
            {
                Name = "Sylas",
                Bio = "Good"
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