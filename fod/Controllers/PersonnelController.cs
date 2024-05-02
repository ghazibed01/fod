using fod.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fod.Controllers
{
    [Authorize] // Restreint l'accès aux utilisateurs connectés
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly GestionVisiteDBContext _context;

        public PersonnelController(GestionVisiteDBContext context)
        {
            _context = context;
        }

        // GET: api/Personnel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personnel>>> GetPersonnel()
        {
            return await _context.Personnel.ToListAsync();
        }

        // GET: api/Personnel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personnel>> GetPersonnel(int id)
        {
            var personnel = await _context.Personnel.FindAsync(id);

            if (personnel == null)
            {
                return NotFound();
            }

            return personnel;
        }

        // POST: api/Personnel
        [HttpPost]
        public async Task<ActionResult<Personnel>> PostPersonnel(Personnel personnel)
        {
            _context.Personnel.Add(personnel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonnel), new { id = personnel.Id }, personnel);
        }

        // PUT: api/Personnel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnel(int id, Personnel personnel)
        {
            if (id != personnel.Id)
            {
                return BadRequest();
            }

            _context.Entry(personnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelExists(id))
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

        // DELETE: api/Personnel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnel(int id)
        {
            var personnel = await _context.Personnel.FindAsync(id);
            if (personnel == null)
            {
                return NotFound();
            }

            _context.Personnel.Remove(personnel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonnelExists(int id)
        {
            return _context.Personnel.Any(e => e.Id == id);
        }
    }
}