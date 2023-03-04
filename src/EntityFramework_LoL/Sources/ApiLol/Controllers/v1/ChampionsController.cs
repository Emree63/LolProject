﻿using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly IDataManager _manager;
        private readonly ILogger<ChampionsController> _logger;
        public ChampionsController(IDataManager dataManager, ILogger<ChampionsController> logger)
        {
            _logger = logger;
            this._manager = dataManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {

            int nbTotal = await _manager.ChampionsMgr.GetNbItems();

            _logger.LogInformation($"method Get call");
            IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(pageRequest.index, pageRequest.count))
                    .Select(x => x.ToDto());
            return Ok(dtos);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation($"method GetByName call with {name}");
            var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                .Select(x => x.ToDto());

            return Ok(dtos);

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto champion)
        {

            _logger.LogInformation($"method Post call");
            return CreatedAtAction(nameof(Get),
                    (await _manager.ChampionsMgr.AddItem(champion.ToModel())).ToDto());

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] ChampionDto champion)
        {

            _logger.LogInformation($"method Put call with {name}");
            var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));

            return Ok(await _manager.ChampionsMgr.UpdateItem(dtos.First(), champion.ToModel()));

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {

            _logger.LogInformation($"method Delete call with {name}");
            var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));

            return Ok(await _manager.ChampionsMgr.DeleteItem(dtos.First()));

        }
    }
}