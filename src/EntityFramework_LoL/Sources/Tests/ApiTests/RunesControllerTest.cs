using ApiLol.Controllers;
using DTO;
using DTO.enums;
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
    public class RunesControllerTest
    {
        private readonly StubData stub;
        private readonly RunesController runes;
        public RunesControllerTest()
        {
            stub = new StubData();
            runes = new RunesController(stub, new NullLogger<RunesController>());
        }

        [TestMethod]
        public async Task TestGetRunes()
        {
            //Arrange

            //Act
            var total = await stub.RunesMgr.GetNbItems();
            var rune = await runes.Get(new PageRequest());

            //Assert
            var objectResult = rune as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var runesResult = objectResult.Value as PageResponse<RuneDto>;
            Assert.IsNotNull(runesResult);

            var result = runesResult.Data as IEnumerable<RuneDto>;
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Count(), total);
            Assert.AreEqual(total, runesResult.total);

        }

        [TestMethod]
        public async Task TestPostRune()
        {
            //Arange
            var runeDto = new RuneDto
            {
                Name = "Project",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Family = RuneFamilyDto.Precision
            };

            //Act
            var total = await stub.RunesMgr.GetNbItems();
            var runesResult = await runes.Post(runeDto);

            //Assert
            var objectResult = runesResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var isRuneDto = objectResult?.Value as RuneDto;
            Assert.IsNotNull(isRuneDto);

            Assert.AreEqual(total + 1, await stub.RunesMgr.GetNbItems());

        }

        [TestMethod]
        public async Task TestCountChampion()
        {
            //Arange
            var runeDto = new RuneDto
            {
                Name = "Project",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Family = RuneFamilyDto.Domination
            };

            //Act
            var oldTotal = await stub.RunesMgr.GetNbItems();
            var oldResult = await runes.GetCountRunes();
            await runes.Post(runeDto);

            var objectResult = oldResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var newTotal = await stub.RunesMgr.GetNbItems();
            var newResult = await runes.GetCountRunes();

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
            var runeDto = new RuneDto
            {
                Name = "Project",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Family = RuneFamilyDto.Precision
            };

            var runeDtoPut = new RuneDto
            {
                Name = "New Project",
                Description = "new Test",
                Icon = "",
                Image = new LargeImageDto(),
                Family = RuneFamilyDto.Unknown
            };

            //Act
            await runes.Post(runeDto);
            var runesResult = await runes.Put(runeDto.Name, runeDtoPut);

            //Assert
            var objectResult = runesResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var rune = objectResult?.Value as RuneDto;
            Assert.IsNotNull(rune);

            Assert.AreNotEqual(runeDto.Description, rune.Description);
            Assert.AreNotEqual(runeDto.Family, rune.Family);

            Assert.AreEqual(runeDtoPut.Description, rune.Description);
            Assert.AreEqual(runeDtoPut.Family, rune.Family);

        }

        [TestMethod]
        public async Task TestDeleteChampion()
        {
            //Arange


            //Act
            var total = await stub.RunesMgr.GetNbItems();
            var runesResult = await runes.Delete("Conqueror");

            //Assert
            var objectResult = runesResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(objectResult.Value, true);
            Assert.AreNotEqual(await stub.RunesMgr.GetNbItems(), total);

        }
    }
}
