using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SatelliteTracker.Pages;

public class PreferitiModel : PageModel
{
    public void OnGet()
    {
    }
    public IActionResult OnPostRemove(int satId)
    {
        var sat = SearchModel.Preferiti.FirstOrDefault(s => s.SatId == satId);
        if (sat != null)
        {
            SearchModel.Preferiti.Remove(sat);
        }
        return RedirectToPage();
    }
}