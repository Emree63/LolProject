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
    public class RunePagesControllerTest
    {
        private readonly StubData stub;
        private readonly RunePagesController runePages;

        public RunePagesControllerTest()
        {
            stub = new StubData();
            runePages = new RunePagesController(stub, new NullLogger<RunePagesController>());
        }

        [TestMethod]
        public async Task TestGetRunePage()
        {
            //Arrange

            //Act
            var total = await stub.RunePagesMgr.GetNbItems();
            var runePage = await runePages.Get(new PageRequest());

            //Assert
            var objectResult = runePage as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var runePResult = objectResult.Value as PageResponse<RunePageDto>;
            Assert.IsNotNull(runePResult);

            var runePagesResult = runePResult.Data as IEnumerable<RunePageDto>;
            Assert.IsNotNull(runePagesResult);

            Assert.AreEqual(runePagesResult.Count(), total);

        }

        [TestMethod]
        public async Task TestCountRunePage()
        {
            //Arange
            var runePageDto = new RunePageDto
            {
                Name = "rune page 2",
                Runes = new Dictionary<string, RuneDto>()
            };

            //Act
            var oldTotal = await stub.RunePagesMgr.GetNbItems();
            var oldResult = await runePages.GetCountRunePages();
            await runePages.Post(runePageDto);

            var newTotal = await stub.RunePagesMgr.GetNbItems();
            var newResult = await runePages.GetCountRunePages();

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
        public async Task TestPostRunePage()
        {
            //Arange
            var runePageDto = new RunePageDto
            {
                Name = "rune page 2",
                Runes = new Dictionary<string, RuneDto>()
            };

            //Act
            var total = await stub.RunePagesMgr.GetNbItems();
            var runePageResult = await runePages.Post(runePageDto);

            //Assert
            var objectResult = runePageResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var rp = objectResult?.Value as RunePageDto;
            Assert.IsNotNull(rp);

            Assert.AreEqual("rune page 2", rp.Name);
            Assert.AreNotEqual(total, await stub.RunePagesMgr.GetNbItems());


        }

        [TestMethod]
        public async Task TestPutRunePage()
        {
            //Arange
            var runePageDto = new RunePageDto
            {
                Name = "rune page 2",
                Runes = new Dictionary<string, RuneDto>()
            };
            var runePageDtoPut = new RunePageDto
            {
                Name = "rune page 3",
                Runes = new Dictionary<string, RuneDto>()
            };

            //Act
            await runePages.Post(runePageDto);
            var runePagesResult = await runePages.Put(runePageDto.Name, runePageDtoPut);

            //Assert
            var objectResult = runePagesResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var rpResult = objectResult?.Value as RunePageDto;
            Assert.IsNotNull(rpResult);

            Assert.AreNotEqual(runePageDto.Name, rpResult.Name);
            Assert.AreEqual(runePageDtoPut.Name, rpResult.Name);

        }

        [TestMethod]
        public async Task TestDeleteRunePage()
        {
            //Arange


            //Act
            var total = await stub.RunePagesMgr.GetNbItems();
            var runePagesResult = await runePages.Delete("rune page 1");

            //Assert
            var objectResult = runePagesResult as NoContentResult;
            Assert.IsNotNull(objectResult);

            Assert.AreNotEqual(await stub.RunePagesMgr.GetNbItems(), total);

        }




    }
}
