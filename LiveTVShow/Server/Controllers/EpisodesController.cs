using LiveTVAdmin.Shared;
using LiveTVShow.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveTVAdmin.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EpisodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisode()
        {
            return await _context.Episode.ToListAsync();
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Episode>> GetEpisode(string id)
        {
            var episode = await _context.Episode.FindAsync(id);

            if (episode == null)
            {
                return NotFound();
            }

            return episode;
        }

        // PUT: api/Episodes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisode(string id, Episode episode)
        {
            if (id != episode.Id)
            {
                return BadRequest();
            }

            _context.Entry(episode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Episodes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Episode>> PostEpisode(Episode episode)
        {
            _context.Episode.Add(episode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EpisodeExists(episode.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEpisode", new { id = episode.Id }, episode);
        }

        // DELETE: api/Episodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Episode>> DeleteEpisode(string id)
        {
            var episode = await _context.Episode.FindAsync(id);
            if (episode == null)
            {
                return NotFound();
            }

            _context.Episode.Remove(episode);
            await _context.SaveChangesAsync();

            return episode;
        }

        private bool EpisodeExists(string id)
        {
            return _context.Episode.Any(e => e.Id == id);
        }
    }
}
