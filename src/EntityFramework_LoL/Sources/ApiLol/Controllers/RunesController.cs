using ApiMapping;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunesController : ControllerBase
    {
        private readonly IDataManager _manager;
        private readonly ILogger<RunesController> _logger;

        public RunesController(IDataManager dataManager, ILogger<RunesController> logger)
        {
            _logger = logger;
            this._manager = dataManager;
        }


        // GET: api/<RunesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            _logger.LogInformation("Executing {Action} - RUNE with parameters: {Parameters}", nameof(Get), pageRequest);
            try
            {
                int nbTotal = await _manager.RunesMgr.GetNbItems();
                if (pageRequest.count == 0)
                {
                    pageRequest = new PageRequest() { index = 0, count = nbTotal, orderingPropertyName = pageRequest.orderingPropertyName, descending = pageRequest.descending, name = pageRequest.name };
                }
                else if (pageRequest.count * pageRequest.index >= nbTotal || pageRequest.count > nbTotal)
                {
                    _logger.LogWarning("too many, maximum {number}", nbTotal);
                    return BadRequest($"Rune limit exceed, max {nbTotal}");
                }

                IEnumerable<RuneDto> dtos;
                if (pageRequest.name == null)
                {
                    dtos = (await _manager.RunesMgr.GetItems(pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDto());
                }
                else
                {
                    dtos = (await _manager.RunesMgr.GetItemsByName(pageRequest.name, pageRequest.index, pageRequest.count, pageRequest.orderingPropertyName, pageRequest.descending))
                        .Select(x => x.ToDto());
                }
                return Ok(new PageResponse<RuneDto> { Data = dtos, index = pageRequest.index, count = pageRequest.count, total = nbTotal });

            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // GET api/<RunesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            _logger.LogInformation("method {Action} - RUNE call with {name}", nameof(Get), name);
            try
            {
                var dtos = (await _manager.RunesMgr.GetItemByName(name, 0, await _manager.RunesMgr.GetNbItems()))
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

        // POST api/<RunesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RuneDto rune)
        {
            _logger.LogInformation("method {Action} - RUNE call with {item}", nameof(Post), rune);
            try
            {
                if (await _manager.RunesMgr.GetNbItemsByName(rune.Name) == 0)
                {
                    return CreatedAtAction(nameof(Get),
                        (await _manager.RunesMgr.AddItem(rune.ToModel())).ToDto());
                }
                _logger.LogWarning($"Name : {rune.Name} is already exist");
                return BadRequest($"Name : {rune.Name} is already exist");
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // PUT api/<RunesController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] RuneDto rune)
        {
            _logger.LogInformation("method {Action} - RUNE call with {name} and {item}", nameof(Put), name, rune);
            try
            {
                var dtos = (await _manager.RunesMgr.GetItemByName(name, 0, await _manager.RunesMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    return NotFound($"Name {name} not exist");
                }
                // Checks if the new name exists
                if (name != rune.Name)
                {
                    var dtos2 = (await _manager.RunesMgr.GetItemByName(rune.Name, 0, await _manager.RunesMgr.GetNbItems()));
                    if (!dtos2.IsNullOrEmpty() || dtos2.Count() > 0)
                    {
                        return BadRequest($"New Name {rune.Name} is already exist");
                    }
                }
                return Ok((await _manager.RunesMgr.UpdateItem(dtos.First(), rune.ToModel())).ToDto());

            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        // DELETE api/<RunesController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation("method {Action} - RUNE call with {name}", nameof(Delete), name);
            try
            {
                var dtos = (await _manager.RunesMgr.GetItemByName(name, 0, await _manager.RunesMgr.GetNbItems()));
                if (dtos.IsNullOrEmpty())
                {
                    _logger.LogWarning("{name} was not found", name);
                    return NotFound($"{name} was not found");
                }
                await _manager.RunesMgr.DeleteItem(dtos.First());
                return NoContent();
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        [HttpGet("/countRunes")]
        public async Task<ActionResult> GetCountRunes()
        {
            _logger.LogInformation("method {Action} - RUNE call", nameof(GetCountRunes));
            try
            {
                return Ok(await _manager.RunesMgr.GetNbItems());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);

            }
        }
    }
}
