using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Data;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class SearchModel : PageModel
{
    private readonly SatelliteService _service;
    private readonly AppDbContext _context;

    public IActionResult OnPost(int satId, string satName, double satLat, double satLng)
    {
        _context.Satellites.Add(new Satellite { SatId = satId, SatName = satName, SatLat = satLat, SatLng = satLng });
        _context.SaveChanges();
        return RedirectToPage();
    }


    [BindProperty]
    public string SearchTerm { get; set; }
    public List<Satellite> Satellites { get; set; } = new();

    public SearchModel(SatelliteService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        var allSatellites = await _service.GetSatellitesAsync();

        if (!string.IsNullOrEmpty(SearchTerm))
        {
            Satellites = allSatellites
                .Where(s => s.SatName != null &&
                            s.SatName.ToLower().Contains(SearchTerm.ToLower()))
                .ToList();
        }
        else
        {
            Satellites = allSatellites;
        }
    }

    public async Task<IActionResult> OnGetSatellite(int satId)
    {
        var sat = await _service.GetSatellitePosition(satId);
        return new JsonResult(sat);
    }

}