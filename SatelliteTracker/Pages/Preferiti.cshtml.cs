using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Data;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class PreferitiModel : PageModel
{
    private readonly AppDbContext _context;

    public List<Satellite> Satellites { get; set; } = new();
    public PreferitiModel(AppDbContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        Satellites = _context.Satellites.ToList();
    }
    public IActionResult OnPostRemove(int satId)
    {
        var sat = _context.Satellites.FirstOrDefault(s => s.SatId == satId);
        if (sat != null)
        {
            _context.Satellites.Remove(sat);
            _context.SaveChanges();
        }
        return RedirectToPage();
    }
}