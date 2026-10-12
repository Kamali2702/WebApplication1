using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogueAPI.Data;
using MovieCatalogueAPI.Models;

namespace MovieCatalogueAPI.Controllers
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

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(
            string? search,
            string? genre)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m =>
                    m.Title.Contains(search));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m =>
                    m.Genre == genre);
            }

            return await query.ToListAsync();
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMovie),
                new { id = movie.Id },
                movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(
            int id,
            Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            var existingMovie =
                await _context.Movies.FindAsync(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Language = movie.Language;
            existingMovie.DurationMinutes =
                movie.DurationMinutes;
            existingMovie.ReleaseYear =
                movie.ReleaseYear;

            await _context.SaveChangesAsync();

            return Ok(existingMovie);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie =
                await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}