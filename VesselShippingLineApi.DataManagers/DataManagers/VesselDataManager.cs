namespace VesselShippingLineApi.DataManagers
{
    /// <summary>
    /// Vessel Data Manupulation Class
    /// </summary>
    public class VesselDataManager : IVesselDataManager
    {
        readonly IDBManager _IDBManager;
        readonly IVesselBAL _IShipBAL;
        public VesselDataManager(IDBManager dbmanager,IVesselBAL shipbal)
        {
            _IDBManager = dbmanager;
            _IShipBAL = shipbal;
        }
        public List<VesselDTO> ShowAllShips()
        {
            List<VesselDTO> lShipModel = new List<VesselDTO>();
            _IDBManager.InitDbCommand("usp_List_All_Ship", System.Data.CommandType.StoredProcedure);
            DataTable dtShowAllShips = _IDBManager.ExecuteDataTable();
            foreach (DataRow row in dtShowAllShips.Rows)
            {
                lShipModel.Add(new VesselDTO()
                {
                    ShipId = row["PK_ShipId"].ConvertDBNullToInt(),
                    ShipName = row["ShipName"].ConvertDBNullToString(),
                    Latitude = row["CurrentLatitude"].ConvertDBNullToDouble(),
                    Longitude = row["CurrentLongitude"].ConvertDBNullToDouble(),
                    Velocity = row["ShipVelocity"].ConvertDBNullToDouble(),

                });
            }
            return lShipModel;
        }

        public AddShipResponse AddShips(AddVesselRequestModel oShip)
        {
            _IDBManager.InitDbCommand("usp_Add_Ship", CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipName_In", oShip.ShipName);
            _IDBManager.AddCMDParam("@ShipVelocity_In", oShip.Velocity);
            _IDBManager.AddCMDParam("@Latitude_In", oShip.Latitude);
            _IDBManager.AddCMDParam("@Longitude_In", oShip.Longitude);
            _IDBManager.AddCMDOutParam("@ErrorMsg_Out", DbType.String, 100);
            _IDBManager.AddCMDOutParam("@Identity_Out", DbType.Int32);
            _IDBManager.ExecuteNonQuery();
            string sReturn= _IDBManager.GetOutParam<string>("@ErrorMsg_Out");
            int sIdentity  = _IDBManager.GetOutParam<Int32>("@Identity_Out");
            AddShipResponse oResponse = new AddShipResponse() {
                ErrorDetail = sReturn,
                ShipId = sIdentity
            };
            return oResponse;
        }

        public string UpdateShipVelocity(VelocityRequestModel oVelocityModel)
        {
            bool bReturn = false;
            
            _IDBManager.InitDbCommand("usp_Update_Ship_Velocity", System.Data.CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipId_In", oVelocityModel.ShipId);
            _IDBManager.AddCMDParam("@ShipVelocity_In", oVelocityModel.Velocity);
            _IDBManager.AddCMDParam("@Longitude_In", oVelocityModel.Longitude);
            _IDBManager.AddCMDParam("@Latitude_In", oVelocityModel.Latitude);
            _IDBManager.AddCMDOutParam("@ErrorMsg_Out", DbType.String,1000);
            _IDBManager.ExecuteNonQuery();
            string sReturn =_IDBManager.GetOutParam<string>("@ErrorMsg_Out");
            return sReturn;
        }
        public List<PortsDTO> GetAllPortList()
        {
            List<PortsDTO> lPortsDTO = new List<PortsDTO>();
            _IDBManager.InitDbCommand("usp_Port_All_List", System.Data.CommandType.StoredProcedure);
            DataTable dtPortList = _IDBManager.ExecuteDataTable();
            if (dtPortList != null && dtPortList.Rows.Count > 0)
            {
                foreach (DataRow row in dtPortList.Rows)
                {
                    lPortsDTO.Add(new PortsDTO() {
                    PortName=row["PortName"].ConvertDBNullToString(),
                       Latitude = row["Latitude"].ConvertDBNullToDouble(),
                       Longitude = row["Longitude"].ConvertDBNullToDouble()
                    });
                }
            }
                return lPortsDTO;
        }
        public VesselDTO GetShipDetail(int iShipId)
        {
            VesselDTO? oShipDTO = null;
            _IDBManager.InitDbCommand("usp_Ship_Details", System.Data.CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipId_In", iShipId);
            DataTable dtShipDetail = _IDBManager.ExecuteDataTable();
            if (dtShipDetail != null && dtShipDetail.Rows.Count > 0)
            {
                DataRow row = dtShipDetail.Rows[0];
                oShipDTO = new VesselDTO() {
                    Latitude = row["CurrentLatitude"].ConvertDBNullToDouble(),
                    Longitude = row["CurrentLongitude"].ConvertDBNullToDouble(),
                    ShipName = row["ShipName"].ConvertDBNullToString(),
                    Velocity = row["ShipVelocity"].ConvertDBNullToDouble()
                };
            }
            return oShipDTO;
        }
        public VesselETAReponseModel GetNearestPortForShip(int iShipId)
        {
            VesselDTO? oShipDTO = new VesselDTO();
            List<PortsDTO> lPortsDTO = new List<PortsDTO>();
            List<Vessel_ETA_DTO> lvessel_ETA_DTOs = new List<Vessel_ETA_DTO>();           


            oShipDTO = GetShipDetail(iShipId);
            if (oShipDTO != null && oShipDTO.Velocity > 0)
            {
                lPortsDTO = GetAllPortList();

                lvessel_ETA_DTOs = _IShipBAL.CalculateLAT(oShipDTO, lPortsDTO);
                Vessel_ETA_DTO oVesselETADTO = lvessel_ETA_DTOs.OrderBy(x => x.ETA).First();
                return new VesselETAReponseModel()
                {
                    Distance = oVesselETADTO.Distance,
                    ETA = _IShipBAL.ConvertTimeSpanETAToStringETA(oVesselETADTO.ETA),
                    PortName = oVesselETADTO.PortName,
                    ShipName = oVesselETADTO.ShipName,
                    Velocity = oVesselETADTO.Velocity
                };
            }
            else if (oShipDTO != null && oShipDTO.Velocity == 0)
            {
                return new VesselETAReponseModel() { Velocity=0};
            }
            return null;
        }

        public VesselDBOutputResponse GetNearestPortForShipDB(int iShipId)
        {
            VesselDBOutputResponse oVesselDBOutputResponse = new VesselDBOutputResponse();
            VesselETAReponseModel oShipClosesPort = null;

            _IDBManager.InitDbCommand("usp_Get_Nearest_Port", System.Data.CommandType.StoredProcedure);
            _IDBManager.AddCMDParam("@ShipId_In", iShipId);
            _IDBManager.AddCMDOutParam("@ErrorMsg_Out", DbType.String, 100);
            DataTable dtNearstPort = _IDBManager.ExecuteDataTable();
            string sReturn = _IDBManager.GetOutParam<string>("@ErrorMsg_Out");
            oVesselDBOutputResponse.sErrorMsg = sReturn;
            if (dtNearstPort != null && dtNearstPort.Rows.Count > 0)
            {
                DataRow row = dtNearstPort.Rows[0];
                TimeSpan t = TimeSpan.FromHours(row["ETA"].ConvertDBNullToDouble());
                int day = t.Days;
                int hour = t.Hours;
                double days = t.TotalMinutes / 60 / 24;
                double hours = (t.TotalMinutes - days * 24 * 60) / 60;
                oShipClosesPort = new VesselETAReponseModel()
                {
                    ShipName= row["ShipName"].ConvertDBNullToString(),
                    PortName = row["PortName"].ConvertDBNullToString(),
                    Distance = Math.Round(row["distance"].ConvertDBNullToDouble(), 2, MidpointRounding.AwayFromZero),
                    Velocity = row["Velocity"].ConvertDBNullToDouble(),
                    ETA = _IShipBAL.ConvertTimeSpanETAToStringETA(row["ETA"].ConvertDBNullToDouble())
                };
            }
            oVesselDBOutputResponse.oVesselETAReponseModel = oShipClosesPort;
            return oVesselDBOutputResponse;
        }

   
    }
}
