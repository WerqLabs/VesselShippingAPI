namespace VesselShippingLineApi.Extensions
{
    /// <summary>
    /// Extension Code to Handle DB Null
    /// </summary>
    public static class ExtensionCode
    {
        /// <summary>
        /// Convert DB null value to Blank else return the value
        /// </summary>
        /// <param name="sValue">Value received from Database</param>
        /// <returns>Blank or Value</returns>
        public static string ConvertDBNullToString(this object sValue, bool IsCasingRequired = false)
        {
            if (sValue == DBNull.Value)
            { return ""; }
            return Convert.ToString(sValue);
        }
        /// <summary>
        /// Convert DB null value to zero or the value
        /// </summary>
        /// <param name="sValue">Value received from Database</param>
        /// <returns>0 or value</returns>
        public static int ConvertDBNullToInt(this object sValue)
        {
            if (((sValue != null && string.IsNullOrEmpty(sValue.ToString())) || (sValue != null && string.IsNullOrWhiteSpace(sValue.ToString()))) || sValue == DBNull.Value)
            { return 0; }
            return Convert.ToInt32(sValue);
        }
        /// <summary>
        /// Convert DB null value to 0 or the value
        /// </summary>
        /// <param name="sValue">Value received from Database</param>
        /// <returns>0 or value</returns>
        public static double ConvertDBNullToDouble(this object sValue)
        {
            if (sValue == DBNull.Value)
            { return 0; }
            return Convert.ToDouble(sValue);
        }
       
    }
}

