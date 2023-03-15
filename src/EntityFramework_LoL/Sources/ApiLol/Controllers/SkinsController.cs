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
            _logger.LogInformation("Executing {Action} - SKIN with parameters: {Parameters}", nameof(Get), pageRequest);
            try
            {
                int nbTotal = await _manager.SkinsMgr.GetNbItems();
                if (pageRequest.count == 0)
                {
                    pageRequest = new PageRequest() { index = 0, count = nbTotal, orderingPropertyName = pageRequest.orderingPropertyName, descending = pageRequest.descending, name = pageRequest.name };
                }
                else if (pageRequest.count * pageRequest.index >= nbTotal || pageRequest.count > nbTotal)
                {
                    _logger.LogWarning("too many, maximum {number}", nbTotal);
                    return BadRequest($"Skin limit exceed, max {nbTotal}");
                }

                IEnumerable<SkinDtoC> dtos;
                if (pageRequest.name == null)
                {
                    dtos = (await _manager.SkinsMgr.GetItems(pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                    .Select(x => x.ToDtoC());
                }
                else
                {
                    dtos = (await _manager.SkinsMgr.GetItemsByName(pageRequest.name, pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDtoC());
                }
                return Ok(new PageResponse<SkinDtoC> { Data = dtos, index = pageRequest.index, count = pageRequest.count, total = nbTotal });

            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // GET api/<SkinsController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation("method {Action} - SKIN call with {name}", nameof(Get), name);
            try
            {
                var dtos = (await _manager.SkinsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                    .Select(x => x.ToDtoC());
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

        // POST api/<SkinsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SkinDtoC skin)
        {
            _logger.LogInformation("method {Action} - SKIN call with {item}", nameof(Post), skin);
            try
            {
                if (skin.ChampionName != null)
                {
                    var dtos = (await _manager.ChampionsMgr.GetItemByName(skin.ChampionName, 0, await _manager.ChampionsMgr.GetNbItems()));
                    if (dtos.IsNullOrEmpty())
                    {
                        _logger.LogWarning($"Champion Name : {skin.ChampionName} not exist");
                        return BadRequest($"Champion Name : {skin.ChampionName} not exist");
                    }
                    else
                    {
                        if (await _manager.SkinsMgr.GetNbItemsByName(skin.Name) == 0)
                        {
                            return CreatedAtAction(nameof(Get),
                                (await _manager.SkinsMgr.AddItem(skin.ToModelC(dtos.First()))).ToDtoC());
                        }
                        _logger.LogWarning($"Name : {skin.Name} is already exist");
                        return BadRequest($"Name : {skin.Name} is already exist");
                    }
                }
                else
                {
                    return BadRequest("Please fill in the name of the champion");
                }
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // PUT api/<SkinsController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] SkinDtoC skin)
        {
            _logger.LogInformation("method {Action} - SKIN call with {name} and {item}", nameof(Put), name, skin);
            try
            {
                var dtos = (await _manager.SkinsMgr.GetItemByName(name, 0, await _manager.SkinsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    return NotFound($"Name {name} not exist");
                }
                // Checks if the new name exists
                if (name != skin.Name)
                {
                    var dtos2 = (await _manager.SkinsMgr.GetItemByName(skin.Name, 0, await _manager.SkinsMgr.GetNbItems()));
                    if (dtos2.IsNullOrEmpty() || dtos2.Count() > 0)
                    {
                        return BadRequest($"New Name {skin.Name} is already exist");
                    }
                }
                var dtosChampion = (await _manager.ChampionsMgr.GetItemByName(skin.ChampionName, 0, await _manager.ChampionsMgr.GetNbItems()));
                if (dtosChampion.IsNullOrEmpty())
                {
                    _logger.LogWarning($"Champion Name : {skin.ChampionName} not exist");
                    return BadRequest($"Champion Name : {skin.ChampionName} not exist");
                }
                return Ok((await _manager.SkinsMgr.UpdateItem(dtos.First(), skin.ToModelC(dtosChampion.First()))).ToDtoC());

            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        [HttpGet("/{name}/champion")]
        public async Task<ActionResult<ChampionDto>> GetChampionBySkinName(string name)
        {
            _logger.LogInformation("method {Action} - Skin call with {name}", nameof(GetChampionBySkinName), name);
            try
            {
                var dtos = (await _manager.SkinsMgr.GetItemByName(name, 0, await _manager.ChampionsMgr.GetNbItems()))
                    .Select(x => x.ToDtoC());
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning($"{name} was not found");
                    return NotFound($"{name} was not found");
                }
                var champion = (await _manager.ChampionsMgr.GetItemByName(dtos.First().ChampionName, 0, 1));
                return Ok(champion.First().ToDto());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }


        [HttpGet("/countSkins")]
        public async Task<ActionResult<int>> GetCountSkins()
        {
            try
            {
                return Ok(await _manager.SkinsMgr.GetNbItems());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // DELETE api/<SkinsController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation("method {Action} - SKIN call with {name}", nameof(Delete), name);
            try
            {
                var dtos = (await _manager.SkinsMgr.GetItemByName(name, 0, await _manager.SkinsMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning("{name} was not found", name);
                    return BadRequest();
                }
                return Ok(await _manager.SkinsMgr.DeleteItem(dtos.First()));
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
    }
}
