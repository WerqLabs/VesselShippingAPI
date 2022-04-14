namespace VesselShippingLineApi.IBAL
{
    /// <summary>
    /// Interface for ETA Calculation
    /// </summary>
    public interface IVesselBAL
    {
        /// <summary>
        /// Calculate ETA
        /// </summary>
        /// <param name="oShipModel">Ship Model Object</param>
        /// <param name="lPortsDTOs">List Ports</param>
        /// <returns>Returns List of Port with there distance and ETA</returns>
        List<Vessel_ETA_DTO> CalculateLAT(VesselDTO? oShipModel, List<PortsDTO> lPortsDTO);
        /// <summary>
        /// Convert Time Span to ETA String days hours and minutes
        /// </summary>
        /// <param name="ETA">Time taken for ship</param>
        /// <returns>Returns time span to formated days hours minutes</returns>
        string ConvertTimeSpanETAToStringETA(double ETA);
    }
}
