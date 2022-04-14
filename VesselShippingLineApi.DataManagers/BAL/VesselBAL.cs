namespace VesselShippingLineApi.BAL
{
    /// <summary>
    /// Vessel BAL to calculate ETA
    /// </summary>
    public class VesselBAL : IVesselBAL
    {
        
        List<Vessel_ETA_DTO> lETAModel = new List<Vessel_ETA_DTO>();
        public List<Vessel_ETA_DTO> CalculateLAT(VesselDTO oShipModel, List<PortsDTO> lPortModel)
        {
            double varDistance = 0.00;
            dynamic varETA ;

            foreach (PortsDTO oPortModel in lPortModel)
            {
                 varDistance = GetDistanceFromLatLonInKn(Convert.ToDecimal(oPortModel.Latitude), Convert.ToDecimal(oPortModel.Longitude), Convert.ToDecimal(oShipModel.Latitude), Convert.ToDecimal(oShipModel.Longitude));

                 varETA = (varDistance / oShipModel.Velocity);
                if (double.IsInfinity(varETA))
                {
                    continue;
                }
                Vessel_ETA_DTO objETAModel = new Vessel_ETA_DTO()
                {
                    Distance= Math.Round(varDistance, 2, MidpointRounding.AwayFromZero),
                    PortName = oPortModel.PortName,
                    ShipName = oShipModel.ShipName,
                    Velocity = oShipModel.Velocity,
                    ETA = varETA
                };

                lETAModel.Add(objETAModel);
            }
            return lETAModel;
        }
        
       double GetDistanceFromLatLonInKn(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = Deg2Rad(lat2 - lat1);  // deg2rad below
            var dLon = Deg2Rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d* 0.539957;
        }

        double Deg2Rad(decimal deg)
        {
            return Convert.ToDouble(deg) * (Math.PI / 180);
        }

        public string ConvertTimeSpanETAToStringETA(double ETA)
        {
            TimeSpan t = TimeSpan.FromHours(ETA);
            int day = t.Days;
            int hour = t.Hours;
            double days = t.TotalMinutes / 60 / 24;
            double hours = (t.TotalMinutes - days * 24 * 60) / 60;

            if (Convert.ToInt32(t.Days) > 0)
            {
                return string.Format("{0:D2} days {1:D2}h:{2:D2}m", Convert.ToInt32(t.Days), Convert.ToInt32(t.Hours),
                            t.Minutes);
            }
            else
            {
                return string.Format("{0:D2}h:{1:D2}m",
                          t.Hours,
                          t.Minutes);
            }
        }
    }
}
