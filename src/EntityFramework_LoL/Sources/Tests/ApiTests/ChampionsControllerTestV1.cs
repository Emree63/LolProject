using ApiLol.Controllers.v1;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using StubLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    [TestClass]
    public class ChampionsControllerTestV1
    {
        private readonly StubData stub;
        private readonly ChampionsController champs;
        public ChampionsControllerTestV1()
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
                {
                    new SkinDto()  {Name = "Project", Description = "Test", Icon = "",Image = new LargeImageDto(),Price = 900 }
                },
                Skills = new List<SkillDto>()
                {
                    new SkillDto() {Name = "Test skill", Description="Empty", Type = SkillTypeDto.Unknown}
                },
                Characteristics = {}
            };

            //Act
            var championsResult = await champs.Post(ChampionDto);

            //Assert
            var objectResult = championsResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var champions = objectResult?.Value as ChampionDto;
            Assert.IsNotNull(champions);

            Assert.AreEqual("Sylas", champions.Name);

            Assert.AreEqual("Project", champions.Skins.First().Name);
            Assert.AreEqual("Test", champions.Skins.First().Description);

            Assert.AreEqual("Test skill", champions.Skills.First().Name);
            Assert.AreEqual("Empty", champions.Skills.First().Description);

        }

        [TestMethod]
        public async Task TestCountChampion()
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
                {
                    new SkinDto()  {Name = "Project", Description = "Test", Icon = "",Image = new LargeImageDto(),Price = 900 }
                },
                Skills = new List<SkillDto>()
                {
                    new SkillDto() {Name = "Test skill", Description="Empty", Type = SkillTypeDto.Unknown}
                }
            };

            //Act
            var oldTotal = await stub.ChampionsMgr.GetNbItems();
            var oldResult = await champs.GetCountChampions();
            await champs.Post(ChampionDto);

            var objectResult = oldResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var newTotal = await stub.ChampionsMgr.GetNbItems();
            var newResult = await champs.GetCountChampions();

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
                {
                    new SkinDto()  {Name = "Project", Description = "Test", Icon = "",Image = new LargeImageDto(),Price = 900 }
                },
                Skills = new List<SkillDto>()
                {
                    new SkillDto() {Name = "Test skill", Description="Empty", Type = SkillTypeDto.Unknown}
                }
            };
            var ChampionDtoPut = new ChampionDto
            {
                Name = "Sylas",
                Bio = "Bad",
                Class = ChampionClassDto.Tank,
                Icon = "",
                Image = new LargeImageDto() { Base64 = "" },
                Skins = new List<SkinDto>(),
                Skills = new List<SkillDto>()
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
