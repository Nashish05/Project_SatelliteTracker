using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class SearchModel : PageModel
{
    private readonly SatelliteService _service;
    public static List<Satellite> Preferiti = new();

    public IActionResult OnPost(int satId , string satName)
    {
        Preferiti.Add(new Satellite { SatId = satId, SatName = satName });

        return RedirectToPage();
    }

    public List<Satellite> Satellites { get; set; } = new();

    public SearchModel(SatelliteService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        Satellites = await _service.GetSatellitesAsync();
    }
}