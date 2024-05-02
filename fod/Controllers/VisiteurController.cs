using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fod.Models;

namespace fod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiteurController : ControllerBase
    {
        private readonly GestionVisiteDBContext _context;

        public VisiteurController(GestionVisiteDBContext context)
        {
            _context = context;
        }

        // GET: api/Visiteur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visiteur>>> GetVisiteurs()
        {
            return await _context.Visiteurs.ToListAsync();
        }

        // GET: api/Visiteur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visiteur>> GetVisiteur(int id)
        {
            var visiteur = await _context.Visiteurs.FindAsync(id);

            if (visiteur == null)
            {
                return NotFound();
            }

            return visiteur;
        }

        // POST: api/Visiteur
        [HttpPost]
        public async Task<ActionResult<Visiteur>> PostVisiteur(Visiteur visiteur)
        {
            _context.Visiteurs.Add(visiteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisiteur), new { id = visiteur.Id }, visiteur);
        }

        // PUT: api/Visiteur/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisiteur(int id, Visiteur visiteur)
        {
            if (id != visiteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(visiteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisiteurExists(id))
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

        // DELETE: api/Visiteur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisiteur(int id)
        {
            var visiteur = await _context.Visiteurs.FindAsync(id);
            if (visiteur == null)
            {
                return NotFound();
            }

            _context.Visiteurs.Remove(visiteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisiteurExists(int id)
        {
            return _context.Visiteurs.Any(e => e.Id == id);
        }
    }
}