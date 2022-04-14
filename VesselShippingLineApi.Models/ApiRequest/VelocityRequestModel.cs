namespace VesselShippingLineApi.Models.ApiRequest
{
    /// <summary>
    /// Velocity Request Model 
    /// </summary>
    public class VelocityRequestModel
    {
        [Required]
        public int? ShipId { get; set; }
        [Required]
        public double? Velocity { get; set; }
        [Range(-90, 90, ErrorMessage = "Latitude should be between -90 and 90 range")]
        [Required(ErrorMessage = "Latitude cannot be empty or null, Latitude should be between -90 and 90 range")]
        public double? Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Longitude should be between -180 and 180 range")]
        [Required(ErrorMessage = "Longitude cannot be empty or null, Longitude should be between -180 and 180 range")]
        public double? Longitude { get; set; }
    }
}
