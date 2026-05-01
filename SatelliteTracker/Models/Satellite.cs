using System.Text.Json.Serialization;

namespace SatelliteTracker.Models;

public class Satellite
{
    public int Id { get; set; }
    [JsonPropertyName("satname")]
    public string SatName { get; set; }

    [JsonPropertyName("satid")]
    public int SatId { get; set; }
}