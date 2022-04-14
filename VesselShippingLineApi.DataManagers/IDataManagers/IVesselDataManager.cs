namespace VesselShippingLineApi.IDataManagers
{
    /// <summary>
    /// Interface for Vessel Data manager
    /// </summary>
    public interface IVesselDataManager
    {
        /// <summary>
        /// Add the Ship
        /// </summary>
        /// <param name="oShipModel"> Json Model with parameters as
        /// ShipName = Name Of the Ship should be max 100 characters
        /// Longitude = Cordinates of Ship Logitude should be in double
        /// Latitude = Cordinates of Ship Latitude should be in double
        /// Velocity = Velocity of the ship should be in double
        ///</param>
        ///Returns AddShipReponse Object
        AddShipResponse AddShips(AddVesselRequestModel oShip);
        /// <summary>
        /// Show All Ships Lists
        /// </summary>
        /// <returns>Array List of All Ships</returns>
        /// List of Ships
        List<VesselDTO> ShowAllShips();
        /// <summary>
        /// Update Ship Velocity
        /// </summary>
        /// <param name="oVelocityModel"> Json Model with parameters as
        /// ShipCode = Existing Ship Id datatype int;
        /// Velocity = Speed of the Ship datatype double
        /// Latitude = Coordinate of ship Latitude
        /// Longitude = Coordinate of ship Longitude
        /// <returns>Return true if sucessfully saved else error details</returns>
        string UpdateShipVelocity(VelocityRequestModel oVelocityModel);


        List<PortsDTO> GetAllPortList();

        /// <summary>
        /// Detail of Port And Ship which is nearst of Port from DB
        /// </summary>
        /// <param name="iShipId">Ship Unique Id</param>
        /// <returns>Object with port information</returns>
        VesselDBOutputResponse GetNearestPortForShipDB(int iShipId);

        /// <summary>
        /// Detail of Port And Ship which is nearst of Port 
        /// </summary>
        /// <param name="iShipId">Ship Unique Id</param>
        /// <returns>Object with port information</returns>
        VesselETAReponseModel GetNearestPortForShip(int iShipId);


    }
}
