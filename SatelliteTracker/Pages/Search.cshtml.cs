using Microsoft.AspNetCore.Mvc.RazorPages;
using SatelliteTracker.Models;

namespace SatelliteTracker.Pages;

public class SearchModel : PageModel
{
    private readonly SatelliteService _service;

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