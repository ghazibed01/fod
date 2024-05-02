using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fod.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeVisiteController : ControllerBase
    {
        private readonly GestionVisiteDBContext _context;

        public TypeVisiteController(GestionVisiteDBContext context)
        {
            _context = context;
        }

        // GET: api/TypeVisite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeVisite>>> GetTypeVisites()
        {
            return await _context.TypeVisites.ToListAsync();
        }

        // GET: api/TypeVisite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeVisite>> GetTypeVisite(int id)
        {
            var typeVisite = await _context.TypeVisites.FindAsync(id);

            if (typeVisite == null)
            {
                return NotFound();
            }

            return typeVisite;
        }

        // PUT: api/TypeVisite/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeVisite(int id, TypeVisite typeVisite)
        {
            if (id != typeVisite.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeVisite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeVisiteExists(id))
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

        private bool TypeVisiteExists(int id)
        {
            return _context.TypeVisites.Any(e => e.Id == id);
        }
    }
}