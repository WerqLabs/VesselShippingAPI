namespace VesselShippingLineApi
{
    /// <summary>
    /// DB Manager Factory Create Connection
    /// </summary>
    public class DBManagerFactory
    {
        public IDBManager GetDBManager(string connectionString)
        {
            DbConnection dbconn = new SqlConnection(connectionString);
            return new DBManager(dbconn);
        }


    }
}
