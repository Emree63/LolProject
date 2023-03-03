using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly IDataManager _manager;
        public readonly ILogger<ChampionsController> _logger;
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
                if (pageRequest.count + pageRequest.index > nbTotal)
                {
                    _logger.LogWarning($"too many, maximum {nbTotal}");
                    return BadRequest($"Champion limit exceed, max {nbTotal}");
                }

                _logger.LogInformation($"method Get call");
                IEnumerable<ChampionDto> dtos = (await _manager.ChampionsMgr.GetItems(pageRequest.index, pageRequest.count))
                        .Select(x => x.ToDto());
                return Ok(dtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                _logger.LogInformation($"method GetByName call with {name}");
                var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                    .Select(x => x.ToDto());
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning($"{name} was not found");
                    return NotFound();
                }
                return Ok(dtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto champion)
        {
            try
            {
                _logger.LogInformation($"method Post call");
                var dtos = (await _manager.ChampionsMgr.GetItemsByName(champion.Name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (!dtos.IsNullOrEmpty())
                {
                    return BadRequest("Name is already exist");
                }
                return CreatedAtAction(nameof(Get),
                        (await _manager.ChampionsMgr.AddItem(champion.ToModel())).ToDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] ChampionDto champion)
        {
            try
            {
                _logger.LogInformation($"method Put call with {name}");
                var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    return BadRequest("Name not exist");
                }
                // Checks if the new name exists
                if (name != champion.Name)
                {
                    var dtos2 = (await _manager.ChampionsMgr.GetItemsByName(champion.Name, 0, await _manager.ChampionsMgr.GetNbItems()));
                    if (!dtos.IsNullOrEmpty())
                    {
                        return BadRequest("Name is already exist");
                    }
                }
                return Ok(await _manager.ChampionsMgr.UpdateItem(dtos.First(), champion.ToModel()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("/{name}/skins")]
        public async Task<ActionResult<Skin>> GetChampionsSkins(string name)
        {
            try
            {
                var champions = await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems());
                //skinsDTO
                IEnumerable<SkinDto> res = champions.First().Skins.Select(e => e.ToDto());

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("/{name}/skills")]
        public async Task<ActionResult<Skin>> GetChampionsSkills(string name)
        {
            try
            {
                var champions = await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems());
                //SkillDTO
                IEnumerable<SkillDto> res = champions.First().Skills.Select(e => e.ToDto());

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                _logger.LogInformation($"method Delete call with {name}");
                var dtos = (await _manager.ChampionsMgr.GetItemsByName(name, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning($"{name} was not found");
                    return BadRequest();
                }
                return Ok(await _manager.ChampionsMgr.DeleteItem(dtos.First()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}