using Idfy.QuartzExtensions.Core;

namespace Idfy.QuartzExtensions.PostgreSql
{
    public class QuartzPostgreSqlConfiguration : QuartzConfiguration
    {
        public QuartzPostgreSqlConfiguration(string instanceName, string connectionString) : base(instanceName, connectionString)
        {
            DataSource.Provider = "Npgsql";
            JobStore.DriverDelegateType = "Quartz.Impl.AdoJobStore.PostgreSQLDelegate, Quartz";
        }
    }
}