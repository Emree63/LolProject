using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        private readonly IDataManager _manager;
        private readonly ILogger<SkinsController> _logger;

        public SkinsController(IDataManager dataManager, ILogger<SkinsController> logger)
        {
            _logger = logger;
            this._manager = dataManager;
        }

        // GET: api/<SkinsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            try
            {
                int nbTotal = await _manager.ChampionsMgr.GetNbItems();
                if (pageRequest.count + pageRequest.index > nbTotal)
                {
                    _logger.LogWarning($"too many, maximum {nbTotal}");
                    return BadRequest($"Champion limit exceed, max {nbTotal}");
                }

                _logger.LogInformation($"method Get call");
                IEnumerable<SkinDtoC> dtos = (await _manager.SkinsMgr.GetItems(pageRequest.index, pageRequest.count))
                    .Select(x => x.ToDtoC());
                return Ok(dtos);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<SkinsController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok();
        }

        // POST api/<SkinsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<SkinsController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<SkinsController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            return Ok();
        }
    }
}
