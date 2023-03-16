﻿using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunePagesController : ControllerBase
    {
        private readonly IDataManager _manager;
        private readonly ILogger<RunePagesController> _logger;

        public RunePagesController(IDataManager dataManager, ILogger<RunePagesController> logger)
        {
            _manager = dataManager;
            _logger = logger;
        }



        // GET: api/<RunePagesController>
/*        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            _logger.LogInformation("Executing {Action} - RUNEPAGE with parameters: {Parameters}", nameof(Get), pageRequest);
            try
            {
                int nbTotal = await _manager.RunePagesMgr.GetNbItems();
                if (pageRequest.count == 0)
                {
                    pageRequest = new PageRequest() { index = 0, count = nbTotal, orderingPropertyName = pageRequest.orderingPropertyName, descending = pageRequest.descending, name = pageRequest.name };
                }
                else if (pageRequest.count * pageRequest.index >= nbTotal || pageRequest.count > nbTotal)
                {
                    _logger.LogWarning("too many, maximum {number}", nbTotal);
                    return BadRequest($"RunePage limit exceed, max {nbTotal}");
                }

                IEnumerable<RunePageDto> dtos;
                if (pageRequest.name == null)
                {
                    dtos = (await _manager.RunePagesMgr.GetItems(pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDto());
                }
                else
                {
                    dtos = (await _manager.RunePagesMgr.GetItemsByName(pageRequest.name, pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDto());
                }
                return Ok(new PageResponse<RunePageDto> { Data = dtos, index = pageRequest.index, count = pageRequest.count, total = nbTotal });

            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }*/

/*        // GET api/<RunePagesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation("method {Action} - RUNEPAGE call with {name}", nameof(Get), name);
            try
            {
                var dtos = (await _manager.RunePagesMgr.GetItemByName(name, 0, await _manager.RunePagesMgr.GetNbItems()))
                    .Select(x => x.ToDto());
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning($"{name} was not found");
                    return NotFound($"{name} was not found");
                }
                return Ok(dtos.First());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // POST api/<RunePagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RunePageDto runePage)
        {
            _logger.LogInformation("method {Action} - RUNEPAGE call with {item}", nameof(Post), runePage);
            try
            {
                if (await _manager.RunePagesMgr.GetNbItemsByName(runePage.Name) == 0)
                {
                    return CreatedAtAction(nameof(Get),
                        (await _manager.RunePagesMgr.AddItem(runePage.ToModel())).ToDto());
                }
                _logger.LogWarning($"Name : {runePage.Name} is already exist");
                return BadRequest($"Name : {runePage.Name} is already exist");
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // PUT api/<RunePagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RunePagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
