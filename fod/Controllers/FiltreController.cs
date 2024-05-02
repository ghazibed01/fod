using fod.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FiltreController : ControllerBase
{
    private readonly GestionVisiteDBContext _context;

    public FiltreController(GestionVisiteDBContext context)
    {
        _context = context;
    }

    [HttpGet("DateFilter")]
    public async Task<ActionResult<IEnumerable<Visite>>> FilterByDate(DateTime? date)
    {
        IQueryable<Visite> query = _context.Visites.Include(v => v.Personnel)
                                                    .Include(v => v.Statut)
                                                    .Include(v => v.TypeVisite);

        query = ApplyDateFilter(query, date);

        return await query.ToListAsync();
    }

    [HttpGet("PersonnelFilter")]
    public async Task<ActionResult<IEnumerable<Visite>>> FilterByPersonnel(string personnelNom)
    {
        IQueryable<Visite> query = _context.Visites.Include(v => v.Personnel)
                                                    .Include(v => v.Statut)
                                                    .Include(v => v.TypeVisite);

        query = ApplyPersonnelFilter(query, personnelNom);

        return await query.ToListAsync();
    }

    [HttpGet("StatutFilter")]
    public async Task<ActionResult<IEnumerable<Visite>>> FilterByStatut(string statutNom)
    {
        IQueryable<Visite> query = _context.Visites.Include(v => v.Personnel)
                                                    .Include(v => v.Statut)
                                                    .Include(v => v.TypeVisite);

        query = ApplyStatutFilter(query, statutNom);

        return await query.ToListAsync();
    }

    [HttpGet("TypeVisiteFilter")]
    public async Task<ActionResult<IEnumerable<Visite>>> FilterByTypeVisite(string typeVisiteNom)
    {
        IQueryable<Visite> query = _context.Visites.Include(v => v.Personnel)
                                                    .Include(v => v.Statut)
                                                    .Include(v => v.TypeVisite);

        query = ApplyTypeVisiteFilter(query, typeVisiteNom);

        return await query.ToListAsync();
    }

    private IQueryable<Visite> ApplyDateFilter(IQueryable<Visite> query, DateTime? date)
    {
        if (date != null)
        {
            query = query.Where(v => v.DateHeureDebut.HasValue && v.DateHeureDebut.Value.Date == date.Value.Date);
        }
        return query;
    }

    private IQueryable<Visite> ApplyPersonnelFilter(IQueryable<Visite> query, string personnelNom)
    {
        if (!string.IsNullOrEmpty(personnelNom))
        {
            query = query.Where(v => v.Personnel != null && v.Personnel.Nom.Contains(personnelNom));
        }
        return query;
    }

    private IQueryable<Visite> ApplyStatutFilter(IQueryable<Visite> query, string statutNom)
    {
        if (!string.IsNullOrEmpty(statutNom))
        {
            query = query.Where(v => v.Statut != null && v.Statut.Nom.Contains(statutNom));
        }
        return query;
    }

    private IQueryable<Visite> ApplyTypeVisiteFilter(IQueryable<Visite> query, string typeVisiteNom)
    {
        if (!string.IsNullOrEmpty(typeVisiteNom))
        {
            query = query.Where(v => v.TypeVisite != null && v.TypeVisite.Nom.Contains(typeVisiteNom));
        }
        return query;
    }
}