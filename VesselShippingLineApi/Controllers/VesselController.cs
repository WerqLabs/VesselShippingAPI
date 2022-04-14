namespace VesselShippingLineApi.Controllers
{
    /// <summary>
    /// Vessel Controller Class
    /// </summary>
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class VesselController : ControllerBase
    {
        /// <summary>
        /// Create Object for Interface IVesselDataManager
        /// </summary>
        readonly IVesselDataManager _IVesselDataManager;
        /// <summary>
        /// Inject IVesselDataManager in _IVesselDataManager
        /// </summary>
        /// <param name="vesselDataManager">Interface of VesselDataManager</param>
        public VesselController(IVesselDataManager vesselDataManager)
        {
            _IVesselDataManager = vesselDataManager;
        }
        /// <summary>
        /// List All the ships
        /// </summary>
        /// <returns>Shows the list of ship in the database</returns>
        [HttpGet("ShowAllShips"), ModelValidationActionFilter]
        [SwaggerHeader("", "", "", true)]
        public IActionResult ShowAllShips()
        {
            List<VesselDTO> data = _IVesselDataManager.ShowAllShips();
            BasicListResponseModel<VesselDTO> result = new(data);
            return Ok(result);
        }
        /// <summary>
        /// Add the Ship
        /// </summary>
        /// <param name="oShipModel"> Json Model with parameters as
        /// ShipName = Name Of the Ship should be max 100 characters
        /// Longitude = Coordinate of Ship Logitude should be in double
        /// Latitude = Coordinate of Ship Latitude should be in double
        /// Velocity = Velocity of the ship should be in double
        ///</param>
        /// <returns>returns Ship Unique Id else return error detail</returns>

        [HttpPost("AddShip"), ModelValidationActionFilter]
        [SwaggerHeader("", "", "", true)]
        public IActionResult AddShip([FromBody] AddVesselRequestModel oShipModel)
        {
            AddShipResponse oReponse = _IVesselDataManager.AddShips(oShipModel);
            if (oReponse != null && !string.IsNullOrEmpty(oReponse.ErrorDetail))
            {
                return BadRequest((ErrorResponseModel)oReponse.ErrorDetail);
            }

            return Ok(new ReceivedAddShipResponse() { ShipId = oReponse.ShipId });
        }
        /// <summary>
        /// Update Ship Velocity
        /// </summary>
        /// <param name="oVelocityModel"> Json Model with parameters as
        /// ShipId = Existing Ship Id datatype int;
        /// Velocity = Speed of the Ship datatype double
        /// Latitude = Coordinate of ship Latitude
        /// Longitude = Coordinate of ship Longitude
        /// </param>
        /// <returns>return 204 if success or Error detail</returns>
        [HttpPut("UpdateShipVelocity"), ModelValidationActionFilter]
        [SwaggerHeader("", "", "", true)]
        public IActionResult UpdateShipVelocity([FromBody] VelocityRequestModel oVelocityModel)
        {
            string sReturn = _IVesselDataManager.UpdateShipVelocity(oVelocityModel);
            if (!string.IsNullOrEmpty(sReturn))
            {
                return BadRequest((ErrorResponseModel)sReturn);
            }
            return StatusCode(204);
        }
        /// <summary>
        /// Get Nearest Port distance to ship speed and Location from database
        /// </summary>
        /// <param name="iShipId">Ship Unique Id</param>
        /// <returns>Returns  Ports</returns>
        [HttpGet("GetNearestPortForShipDB"), ModelValidationActionFilter]
        [SwaggerHeader("", "", "", true)]
        public IActionResult GetNearestPortForShipDB(int iShipId)
        {
            if (iShipId ==0)
            {
                return BadRequest((ErrorResponseModel)"Ship Id Cannot 0");
            }
            VesselDBOutputResponse oShipResponse = _IVesselDataManager.GetNearestPortForShipDB(iShipId);
            if (oShipResponse != null && string.IsNullOrEmpty(oShipResponse.sErrorMsg))
            {
                return Ok(oShipResponse);
            }
            else
            {
               return BadRequest((ErrorResponseModel)oShipResponse.sErrorMsg);
            }

        }

        /// <summary>
        /// Get Nearest Port distance to ship speed and Location
        /// </summary>
        /// <param name="iShipId">Ship Unique Id</param>
        /// <returns>Returns List of Ports</returns>
        [HttpGet("GetNearestPortForShip"), ModelValidationActionFilter]
        [SwaggerHeader("", "", "", true)]
        public IActionResult GetNearestPortForShip(int iShipId)
        {
            if (iShipId == 0)
            {
                return BadRequest((ErrorResponseModel)"Ship Id Cannot 0");
            }
            VesselETAReponseModel oShipResponse = _IVesselDataManager.GetNearestPortForShip(iShipId);
            if (oShipResponse != null && oShipResponse.Velocity == 0)
            {
                return BadRequest((ErrorResponseModel)"Please Update Velocity of the Ship to get ETA, Velocity Cannot be 0");
            }
            else if (oShipResponse != null)
            {
                return Ok(oShipResponse);
            }
            else
            {
                return BadRequest((ErrorResponseModel)"Please Provider valid Ship Id, Record Not Found");
            }

        }

    }
}
