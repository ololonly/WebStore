using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> _values = Enumerable.Range(1, 10).Select(x => $"{x:00}").ToList();

        [HttpGet]
        public IEnumerable<string> Get() => _values;

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id > _values.Count)
                return NotFound();
            else
                return _values[id];

        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            _values.Add(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0)
                return BadRequest();
            else if (id > _values.Count)
                return NotFound();

            _values[id] = value;

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id > _values.Count)
                return NotFound();


            _values.RemoveAt(id);
            return Ok();
        }
    }
}
