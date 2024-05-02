using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fod.Models;

namespace fod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitesController : ControllerBase
    {
        private readonly GestionVisiteDBContext _context;

        public VisitesController(GestionVisiteDBContext context)
        {
            _context = context;
        }

        // GET: api/Visites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visite>>> GetVisites()
        {
            var visites = await _context.Visites.ToListAsync();
            return Ok(new { success = true, message = "Opération réussie", data = visites });
        }

        // GET: api/Visites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visite>> GetVisite(Guid id)
        {
            var visite = await _context.Visites.FindAsync(id);

            if (visite == null)
            {
                return NotFound(new { success = false, message = "Visite non trouvée" });
            }

            return Ok(new { success = true, message = "Opération réussie", data = visite });
        }

        // POST: api/Visites
        [HttpPost]
        public async Task<ActionResult<Visite>> PostVisite(Visite visite)
        {
            _context.Visites.Add(visite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisite), new { id = visite.Uid }, visite);
        }

        // PUT: api/Visites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisite(Guid id, Visite visite)
        {
            if (id != visite.Uid)
            {
                return BadRequest(new { success = false, message = "ID de visite incorrect" });
            }

            _context.Entry(visite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisiteExists(id))
                {
                    return NotFound(new { success = false, message = "Visite non trouvée" });
                }
                else
                {
                    return StatusCode(500, new { success = false, message = "Erreur interne du serveur" });
                }
            }

            return NoContent();
        }

        // DELETE: api/Visites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisite(Guid id)
        {
            var visite = await _context.Visites.FindAsync(id);
            if (visite == null)
            {
                return NotFound(new { success = false, message = "Visite non trouvée" });
            }

            _context.Visites.Remove(visite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisiteExists(Guid id)
        {
            return _context.Visites.Any(e => e.Uid == id);
        }
    }
}