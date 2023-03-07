using ApiLol.Mapper;
using Azure.Core;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
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
            try
            {
                int nbTotal = await _manager.ChampionsMgr.GetNbItems();
                if (pageRequest.count == 0)
                {
                    pageRequest = new PageRequest() { index = 0, count = nbTotal };
                }
                else if (pageRequest.count * pageRequest.index >= nbTotal)
                {
                    _logger.LogWarning($"too many, maximum {nbTotal}");
                    return BadRequest($"Champion limit exceed, max {nbTotal}");
                }

                _logger.LogInformation("Executing {Action} with parameters: {Parameters}", nameof(Get), pageRequest.count);
                IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(pageRequest.index, pageRequest.count))
                        .Select(x => x.ToDto());
                return Ok(dtos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/<ValuesController>
        [HttpGet, MapToApiVersion("3.0")]
        public async Task<IActionResult> GetV3([FromQuery] PageRequest pageRequest)
        {
            try
            {
                int nbTotal = await _manager.ChampionsMgr.GetNbItems();
                if (pageRequest.count == 0)
                {
                    pageRequest = new PageRequest() { index = 0, count = nbTotal };
                }
                else if (pageRequest.count * pageRequest.index >= nbTotal || pageRequest.count > nbTotal)
                {
                    _logger.LogWarning("too many, maximum {number}", nbTotal);
                    return BadRequest($"Champion limit exceed, max {nbTotal}");
                }

                _logger.LogInformation("Executing {Action} with parameters: {Parameters}", nameof(Get), pageRequest);
                IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDto());
                return Ok(new { Data = dtos, index = pageRequest.index, count = pageRequest.count, total = nbTotal});
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {name}", nameof(Get), name);
                var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                    .Select(x => x.ToDto());
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning($"{name} was not found");
                    return NotFound();
                }
                return Ok(dtos.First());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto champion)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {item}", nameof(Post), champion);
                var dtos = (await _manager.ChampionsMgr.GetItemByName(champion.Name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (!dtos.IsNullOrEmpty())
                {
                    return BadRequest("Name is already exist");
                }
                return CreatedAtAction(nameof(Get),
                        (await _manager.ChampionsMgr.AddItem(champion.ToModel())).ToDto());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] ChampionDto champion)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {name} and {item}", nameof(Put), name, champion);
                var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    return NotFound($"Name {name} not exist");
                }
                // Checks if the new name exists
                if (name != champion.Name)
                {
                    var dtos2 = (await _manager.ChampionsMgr.GetItemByName(champion.Name, 0, await _manager.ChampionsMgr.GetNbItems()));
                    if (dtos2.IsNullOrEmpty() || dtos2.Count() > 0)
                    {
                        return BadRequest("Name is already exist");
                    }
                }
                return Ok((await _manager.ChampionsMgr.UpdateItem(dtos.First(), champion.ToModel())).ToDto());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("/{name}/skins")]
        public async Task<ActionResult<SkinDto>> GetChampionsSkins(string name)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {name}", nameof(GetChampionsSkins), name);
                var champions = await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems());
                //skinsDTO
                IEnumerable<SkinDto> res = champions.First().Skins.Select(e => e.ToDto());

                return Ok(res);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("/{name}/skills")]
        public async Task<ActionResult<SkillDto>> GetChampionsSkills(string name)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {name}", nameof(GetChampionsSkills), name);
                var champions = await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems());
                //SkillDTO
                IEnumerable<SkillDto> res = champions.First().Skills.Select(e => e.ToDto());

                return Ok(res);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                _logger.LogInformation("method {Action} call with {name}", nameof(Delete), name);
                var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning("{name} was not found", name);
                    return BadRequest();
                }
                return Ok(await _manager.ChampionsMgr.DeleteItem(dtos.First()));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}