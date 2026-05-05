using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Data;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class SearchModel : PageModel
{
    private readonly SatelliteService _service;
    private readonly AppDbContext _context;

    [BindProperty(SupportsGet = true)]
    public string ZonaSelezionata { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    public List<Satellite> Satellites { get; set; } = new();

    private readonly List<Satellite> globalSatellites = new()
    {
        new Satellite { SatId = 25544, SatName = "ISS (ZARYA)" },
        new Satellite { SatId = 20580, SatName = "HUBBLE" },
        new Satellite { SatId = 25338, SatName = "NOAA 15" },
        new Satellite { SatId = 28654, SatName = "NOAA 18" },
        new Satellite { SatId = 33591, SatName = "TERRA" },
        new Satellite { SatId = 27424, SatName = "AQUA" },
        new Satellite { SatId = 37849, SatName = "SUOMI NPP" },
        new Satellite { SatId = 43013, SatName = "TESS" },
        new Satellite { SatId = 39084, SatName = "FENGYUN 3C" },
        new Satellite { SatId = 41765, SatName = "TIANGONG-2" }
    };

    public SearchModel(SatelliteService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }


    public void OnGet()
    {
        ZonaSelezionata ??= "Mondo";

        Satellites = string.IsNullOrEmpty(SearchTerm)
            ? globalSatellites
            : globalSatellites
                .Where(s => s.SatName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
    }


    public async Task<IActionResult> OnPost(int satId, string satName)
    {
        var satLive = await _service.GetSatellitePosition(satId, 0, 0);

        if (!_context.Satellites.Any(s => s.SatId == satId))
        {
            _context.Satellites.Add(new Satellite
            {
                SatId = satId,
                SatName = satName,
                SatLat = satLive.latitude,
                SatLng = satLive.longitude
            });

            await _context.SaveChangesAsync();
        }

        return RedirectToPage(new
        {
            ZonaSelezionata,
            SearchTerm
        });
    }


    public async Task<IActionResult> OnGetSatellite(int satId, double lat, double lng)
    {
        var sat = await _service.GetSatellitePosition(satId, lat, lng);
        return new JsonResult(sat);
    }
}