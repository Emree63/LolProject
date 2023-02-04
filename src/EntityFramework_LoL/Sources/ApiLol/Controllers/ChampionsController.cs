using ApiLol.Mapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        IChampionsManager dataManager = new StubData().ChampionsMgr;
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var champions = await dataManager.GetItems(0, await dataManager.GetNbItems()); // Le await va permettre que les lignes suivantes ne s'éxécute pas
            return Ok(new { result = champions.Select(c => c.ToDto()) });
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            dataManager.GetItemsByName(name, 0, 1);
            return NotFound();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDto value)
        {
            //await dataManager.AddItem(value.toModel());
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
