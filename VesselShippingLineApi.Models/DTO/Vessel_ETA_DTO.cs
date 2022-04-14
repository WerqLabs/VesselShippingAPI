namespace VesselShippingLineApi.Models.DTO
{
    /// <summary>
    /// Vessel ETA DTO
    /// </summary>
    public class Vessel_ETA_DTO
    {
        public string PortName { get; set; }
        public string ShipName { get; set; }
        public double Distance { get; set; }
        public double ETA { get; set; }
        public double Velocity { get; set; }
    }
}
