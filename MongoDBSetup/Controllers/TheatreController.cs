using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDBSetup.Models;
using MongoDBSetup.Services;

namespace MongoDBSetup.Controllers
{
    [Route("api/theatre")]
    [ApiController]
    public class TheatreController : ControllerBase

    {
        private readonly ITheatreService _TheatreService;

        public TheatreController(ITheatreService theatreService)
        {
            _TheatreService = theatreService;
        }

        // GET: api/<StudentsController>
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult<List<Theatre>> Get()
        {
            return Ok(_TheatreService.Get());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Theatre> Get(string id)
        {
            var theatre = _TheatreService.Get(id);
            if (theatre == null) return NotFound($"Theatre with ID '${id}' not found!");
            return theatre;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Theatre> Post([FromBody] Theatre theatre)
        {
            _TheatreService.Create(theatre);
            return CreatedAtAction(nameof(Get), new { id = theatre.TheatreId }, theatre);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Theatre theatre)
        {
            var existingTheatre = _TheatreService.Get(id);
            if (existingTheatre == null) return NotFound($"Student with ID '${id}' not found!");
            _TheatreService.Update(id, theatre);
            return CreatedAtAction(nameof(Get), new { id = existingTheatre.TheatreId }, theatre);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingTheatre = _TheatreService.Get(id);
            if (existingTheatre == null) return NotFound($"Theatre with ID '${id}' not found!");
            _TheatreService.Delete(id);
            return StatusCode(204, $"Theatre with ID '${id}' deleted.");
        }
    }
}
