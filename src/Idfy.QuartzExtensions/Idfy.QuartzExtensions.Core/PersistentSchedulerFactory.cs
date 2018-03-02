using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Idfy.QuartzExtensions.Core
{
    public static class PersistentSchedulerFactory
    {
        public static async Task<IScheduler> GetDefaultScheduler(string instanceName, string connectionString,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var config = new QuartzConfiguration(instanceName, connectionString);
            return await new StdSchedulerFactory(PropsBuilder.Build(config)).GetScheduler(cancellationToken);
        }

        public static async Task<IScheduler> GetDefaultScheduler(QuartzConfiguration configuration,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await new StdSchedulerFactory(PropsBuilder.Build(configuration)).GetScheduler(cancellationToken);
        }
    }
}