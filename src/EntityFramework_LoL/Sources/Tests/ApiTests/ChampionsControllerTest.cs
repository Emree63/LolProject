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
        private readonly ChampionsControllerTest champs;
        public ChampionsControllerTest()
        {
            stub = new StubData();
            champs = new ChampionsController(stub);
        }

        [TestMethod]
        public async void TestGetChampions()
        {
            //Arrange

            //Act
            var champion = champs.Get();

            //Assert
            var objectResult = champion as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as IEnumerable<Champion>;
            Assert.IsNotNull(champions);

            Assert.AreEqual(champions.Count(), await stub.ChampionsMgr.GetItems(0,5).Count());

        }

        [TestMethod]
        public async Task TestPostChampion()
        {
            //Arange
            var ChampionDto = new ChampionDto
            {
                Name = "Sylas"
            };

            //Act
            var championsResult = await champs.Post(ChampionDto);

            //Assert
            var objectResult = championsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as IEnumerable<Champion>;
            Assert.IsNotNull(champions);

        }

    }
}