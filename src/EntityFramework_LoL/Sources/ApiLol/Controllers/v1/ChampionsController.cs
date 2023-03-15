using ApiLol.Mapper;
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
            _logger.LogInformation("Executing {Action} - CHAMPION - V1.0 with parameters: {Parameters}", nameof(Get), pageRequest);
            IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                .Select(x => x.ToDto());
            return Ok(dtos);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation("method {Action} - CHAMPION - V1.0 call with {name}", nameof(Get), name);
            var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                .Select(x => x.ToDto());

            return Ok(dtos.First());

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto champion)
        {

            _logger.LogInformation("method {Action} - CHAMPION - V1.0 call with {item}", nameof(Post), champion);
            return CreatedAtAction(nameof(Get),
                    (await _manager.ChampionsMgr.AddItem(champion.ToModel())).ToDto());

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] ChampionDto champion)
        {

            _logger.LogInformation("method {Action} - CHAMPION - V1.0 call with {name} and {item}", nameof(Put), name, champion);
            var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));

            return Ok((await _manager.ChampionsMgr.UpdateItem(dtos.First(), champion.ToModel())).ToDto());

        }

        [HttpGet("/countChampions")]
        public async Task<ActionResult> GetCountChampions()
        {
            try
            {
                return Ok(await _manager.ChampionsMgr.GetNbItems());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {

            _logger.LogInformation("method {Action} - CHAMPION - V1.0 call with {name}", nameof(Delete), name);
            var dtos = (await _manager.ChampionsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));

            return Ok(await _manager.ChampionsMgr.DeleteItem(dtos.First()));

        }
    }
}