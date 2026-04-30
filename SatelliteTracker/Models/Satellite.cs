using System.Text.Json.Serialization;

namespace SatelliteTracker.Models;

public class Satellite
{
    [JsonPropertyName("satname")]
    public string SatName { get; set; }

    [JsonPropertyName("satid")]
    public int SatId { get; set; }
}