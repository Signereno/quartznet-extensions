using System;
using System.Threading;
using System.Threading.Tasks;
using Idfy.QuartzExtensions.Core;
using Quartz;

namespace Idfy.QuartzExtensions.PostgreSql
{
    public class PostgreSqlSchedulerFactory
    {
        public static async Task<IScheduler> GetDefaultScheduler(string instanceName, string connectionString,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var configuration = new QuartzPostgreSqlConfiguration(instanceName, connectionString);
            return await GetDefaultScheduler(configuration, cancellationToken);
        }

        public static async Task<IScheduler> GetDefaultScheduler(QuartzPostgreSqlConfiguration configuration,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PersistentSchedulerFactory.GetDefaultScheduler(configuration, cancellationToken);
        }
    }
}