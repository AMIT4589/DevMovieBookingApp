using Microsoft.AspNetCore.Mvc;
using MongoDBSetup.Models;
using MongoDBSetup.Services;

namespace MovieBookingApp.Controllers
{
    [Route("api/moviebooking")]
    [ApiController]
    public class MovieBooking : ControllerBase
    {
        private readonly IMovieService _MovieService;

        public MovieBooking(IMovieService movieService)
        {
            _MovieService = movieService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return Ok(_MovieService.Get());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(string id)
        {
            var student = _MovieService.Get(id);
            if (student == null) return NotFound($"Student with ID '${id}' not found!");
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie student)
        {
            _MovieService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.MovieId }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Movie student)
        {
            var existingStudent = _MovieService.Get(id);
            if (existingStudent == null) return NotFound($"Student with ID '${id}' not found!");
            _MovieService.Update(id, student);
            return CreatedAtAction(nameof(Get), new { id = existingStudent.MovieId }, student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = _MovieService.Get(id);
            if (existingStudent == null) return NotFound($"Student with ID '${id}' not found!");
            _MovieService.Delete(id);
            return StatusCode(204, $"Student with ID '${id}' deleted.");
        }
    }
}
