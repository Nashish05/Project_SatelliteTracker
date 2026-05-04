namespace SatelliteTracker.Models
{
    public class PositionResponse
    {
        public List<PositionData> positions { get; set; }
    }

    public class PositionData
    {
        public double satlatitude { get; set; }
        public double satlongitude { get; set; }
    }

    public class SatellitePosition
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
