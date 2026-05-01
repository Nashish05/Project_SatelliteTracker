using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Data;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class SearchModel : PageModel
{
    private readonly SatelliteService _service;
    private readonly AppDbContext _context;
    public IActionResult OnPost(int satId, string satName)
    {
        _context.Satellites.Add(new Satellite { SatId = satId, SatName = satName });
        _context.SaveChanges();
        return RedirectToPage();
    }

    public List<Satellite> Satellites { get; set; } = new();

    public SearchModel(SatelliteService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Satellites = await _service.GetSatellitesAsync();
    }
}