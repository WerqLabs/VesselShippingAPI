namespace VesselShippingLineApi.Models.ApiResponse
{
    /// <summary>
    /// Vessel ETA Response Model
    /// </summary>
    public class VesselETAReponseModel
    {
        public string PortName { get; set; }
        public string ShipName { get; set; }
        public double Distance { get; set; }
        public string ETA { get; set; }
        public double Velocity { get; set; }
    }
}
