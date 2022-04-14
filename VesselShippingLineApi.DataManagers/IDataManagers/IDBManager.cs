namespace VesselShippingLineApi.IDataManagers
{
    /// <summary>
    /// Interface for DBManager Class
    /// </summary>
    public interface IDBManager
    {
        DBManager InitDbCommand(string cmd);
        DBManager InitDbCommand(string cmd, CommandType cmdtype);
        DBManager AddCMDParam(string parametername, object value);
        DBManager AddCMDParam(string parametername, object value, DbType dbtype);
        DBManager AddCMDOutParam(string parametername, DbType dbtype, int iSize = 0);

        T GetOutParam<T>(string paramname);
        DataTable ExecuteDataTable();
        DataSet ExecuteDataSet();

        object? ExecuteScalar();

        Task<object?> ExecuteScalarAsync();
        int ExecuteNonQuery();
        Task<int> ExecuteNonQueryAsync();
    }
}
