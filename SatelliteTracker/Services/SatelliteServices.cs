using SatelliteTracker.Models;
using System.Text.Json;

public class SatelliteService
{
    private readonly HttpClient _http;
    private readonly string apiKey = "LFZZKJ-2MZRQ3-24WB3R-5QBB";

    public SatelliteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Satellite>> GetSatellitesAsync()
    {
        double lat = 45.4642;
        double lng = 9.1900;
        int alt = 0;
        int radius = 10; 
        int category = 0;

        string url = $"https://api.n2yo.com/rest/v1/satellite/above/{lat}/{lng}/{alt}/{radius}/{category}/&apiKey={apiKey}";

        var response = await _http.GetStringAsync(url);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<ApiResponse>(response, options);

        return data?.above ?? new List<Satellite>();
    }
    public async Task<SatellitePosition> GetSatellitePosition(int satId)
    {
        double lat = 45.4642;
        double lng = 9.1900;
        string url = $"https://api.n2yo.com/rest/v1/satellite/positions/{satId}/{lat}/{lng}/0/1/&apiKey={apiKey}";
        var response = await _http.GetStringAsync(url);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<PositionResponse>(response, options);
        var pos = data.positions[0];

        return new SatellitePosition
        {
            latitude = pos.satlatitude,
            longitude = pos.satlongitude
        };
    }
}