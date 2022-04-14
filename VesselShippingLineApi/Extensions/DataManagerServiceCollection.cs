namespace VesselShippingLineApi.Extensions
{
    /// <summary>
    /// Class initialize ShipBAL and VesselDatamanager
    /// </summary>
    internal static class DataManagerServiceCollection
    {
        internal static IServiceCollection AddDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IDBManager>(AddDBManager);
            services.AddScoped<IVesselDataManager, VesselDataManager>();
            services.AddScoped<IVesselBAL, VesselBAL>();
            return services;
        }

        internal static IDBManager AddDBManager(IServiceProvider serviceProvider)
        {
            IConfiguration Configuration = serviceProvider.GetRequiredService<IConfiguration>();
            
            string dbconstr = Configuration.GetConnectionString("DBConnectionString");
            return new DBManagerFactory().GetDBManager(dbconstr);
        }
    }
}
