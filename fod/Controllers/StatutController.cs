using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fod.Models;

namespace fod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutController : ControllerBase
    {
        private readonly GestionVisiteDBContext _context;

        public StatutController(GestionVisiteDBContext context)
        {
            _context = context;
        }

        // GET: api/Statut
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statut>>> GetStatuts()
        {
            return await _context.Statuts.ToListAsync();
        }

        // GET: api/Statut/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statut>> GetStatut(int id)
        {
            var statut = await _context.Statuts.FindAsync(id);

            if (statut == null)
            {
                return NotFound();
            }

            return statut;
        }

        // PUT: api/Statut/Cloturer/5
        [HttpPut("Cloturer/{id}")]
        public async Task<IActionResult> CloturerStatut(int id)
        {
            var statut = await _context.Statuts.FindAsync(id);
            if (statut == null)
            {
                return NotFound();
            }

            // Mettre à jour le statut en "Cloturé"
            statut.Nom = "Cloturé";
            _context.Entry(statut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatutExists(id))
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

        private bool StatutExists(int id)
        {
            return _context.Statuts.Any(e => e.Id == id);
        }
    }
}