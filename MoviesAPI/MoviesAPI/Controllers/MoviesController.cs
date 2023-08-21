using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<Movies>
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/<Movies>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST api/<Movies>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (movie == null) return BadRequest();
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // PUT api/<Movies>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = _context.Movies.Find(id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Title = updatedMovie.Title;
            existingMovie.RunningTime = updatedMovie.RunningTime;
            existingMovie.Genre = updatedMovie.Genre;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<Movies>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
