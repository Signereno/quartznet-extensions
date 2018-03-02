using Idfy.QuartzExtensions.Core;

namespace Idfy.QuartzExtensions.SqlServer
{
    public class QuartzSqlServerConfiguration : QuartzConfiguration
    {
        public QuartzSqlServerConfiguration(string instanceName, string connectionString) : base(instanceName, connectionString)
        {
            DataSource.Provider = "SqlServer";
            JobStore.DriverDelegateType = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";
        }
    }
}