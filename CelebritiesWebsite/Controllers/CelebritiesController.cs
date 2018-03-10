using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CelebritiesWebsite.Repository;

namespace CelebritiesWebsite.Controllers
{
    [Route("api/[controller]")]
    public class CelebritiesController : Controller
    {
        private readonly ICelebritiesRepository _celebritiesRepository;

        public CelebritiesController(ICelebritiesRepository celebritiesRepository)
        {
            _celebritiesRepository = celebritiesRepository;
        }

        [HttpGet]
        public IEnumerable<Celebrity> Get()
        {
            return _celebritiesRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetCelebrity")]
        public IActionResult Get(int id)
        {
            if (!_celebritiesRepository.IsExists(id))
            {
                return NotFound();
            }
            return new ObjectResult(_celebritiesRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Celebrity celebrity)
        {
            _celebritiesRepository.Add(celebrity);
            return CreatedAtRoute("GetCelebrity", new { id = celebrity.Id }, celebrity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Celebrity celebrity)
        {
            if (id != celebrity.Id)
            {
                return BadRequest("Id from body does not match id from url");
            }
            if(!_celebritiesRepository.IsExists(id))
            {
                return NotFound();
            }
            _celebritiesRepository.Update(id, celebrity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_celebritiesRepository.IsExists(id))
            {
                return NotFound();
            }
            _celebritiesRepository.Remove(id);
            return NoContent();
        }
    }
}
