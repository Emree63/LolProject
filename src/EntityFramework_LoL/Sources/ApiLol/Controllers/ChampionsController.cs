﻿using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly IDataManager _manager;
        public ChampionsController(IDataManager dataManager)
        {
            this._manager = dataManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(0, await _manager.ChampionsMgr.GetNbItems()))
                    .Select(x => x.ToDto());
            return Ok(dtos);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var dtos = (await _manager.ChampionsMgr.GetItemsByName(name,0, await _manager.ChampionsMgr.GetNbItems()))
                .Select(x => x.ToDto());
            if(dtos == null)
            {
                return NotFound();
            }
            return Ok(dtos);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto champion)
        {
            return CreatedAtAction(nameof(Get),
                    (await _manager.ChampionsMgr.AddItem(champion.ToModel())).ToDto());
        }

/*        // PUT api/<ValuesController>/5
        [HttpPut("{name}")]
        public async void Put(string name, [FromBody] ChampionDto champion)
        {
            return Ok(await _manager.ChampionsMgr.UpdateItem(, champion.ToModel()));
        }*/

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ChampionDto champion)
        {
            return Ok(await _manager.ChampionsMgr.DeleteItem(champion.ToModel()));
        }
    }
}
