using System.Text.Json.Serialization;

namespace SatelliteTracker.Models;

public class Satellite
{
    public int Id { get; set; }
    [JsonPropertyName("satname")]
    public string SatName { get; set; }

    [JsonPropertyName("satid")]
    public int SatId { get; set; }

    [JsonPropertyName("satlat")]
    public double? SatLat { get; set; }

    [JsonPropertyName("satlng")]
    public double? SatLng { get; set; }
}