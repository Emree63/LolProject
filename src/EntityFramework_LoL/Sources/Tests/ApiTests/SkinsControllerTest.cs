﻿using ApiLol.Controllers;
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
                Name = "Project",
                Description = "Test",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 900,
                ChampionName = "aatrox"
            };

            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skinsResult = await skins.Post(SkinDto);

            //Assert
            var objectResult = skinsResult as CreatedAtActionResult;
            Assert.IsNotNull(objectResult);

            var isSkinDto = objectResult?.Value as SkinDtoC;
            Assert.IsNotNull(isSkinDto);

            Assert.AreEqual(total+1, await stub.SkinsMgr.GetNbItems());

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
                ChampionName = "aatrox"
            };
            var SkinDtoPut = new SkinDtoC
            {
                Name = "Project",
                Description = "ForTestTest",
                Icon = "",
                Image = new LargeImageDto(),
                Price = 850,
                ChampionName = "aatrox"
            };

            //Act
            await skins.Post(SkinDto);
            var skinsResult = await skins.Put(SkinDto.Name, SkinDtoPut);

            //Assert
            var objectResult = skinsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var skin = objectResult?.Value as SkinDtoC;
            Assert.IsNotNull(skin);

            Assert.AreNotEqual(SkinDto.Description, skin.Description);
            Assert.AreNotEqual(SkinDto.Price, skin.Price);

            Assert.AreEqual(SkinDtoPut.Description, skin.Description);
            Assert.AreEqual(SkinDtoPut.Price, skin.Price);

        }

        [TestMethod]
        public async Task TestDeleteChampion()
        {
            //Arange


            //Act
            var total = await stub.SkinsMgr.GetNbItems();
            var skinsResult = await skins.Delete("Stinger");

            //Assert
            var objectResult = skinsResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(objectResult.Value, true);
            Assert.AreNotEqual(await stub.SkinsMgr.GetNbItems(), total);

        }

    }
}
