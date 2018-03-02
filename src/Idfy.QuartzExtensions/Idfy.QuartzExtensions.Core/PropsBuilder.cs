using System.Collections.Specialized;

namespace Idfy.QuartzExtensions.Core
{
    internal static class PropsBuilder
    {
        internal static NameValueCollection Build(QuartzConfiguration configuration) => new NameValueCollection()
        {
            {"quartz.scheduler.instanceName", configuration.Scheduler.InstanceName},
            {"quartz.scheduler.instanceId", configuration.Scheduler.InstanceId},
            {"quartz.threadPool.type", configuration.ThreadPool.Type},
            {"quartz.threadPool.threadCount", configuration.ThreadPool.ThreadCount.ToString()},
            {"quartz.threadPool.threadPriority", configuration.ThreadPool.ThreadPriority},
            {"quartz.jobStore.useProperties", configuration.JobStore.UseProperties.ToString()},
            {"quartz.jobStore.clustered", configuration.JobStore.Clustered.ToString()},
            {"quartz.jobStore.misfireThreshold", configuration.JobStore.MisfireThreshhold.ToString()},
            {"quartz.jobStore.type", configuration.JobStore.Type},
            {"quartz.jobStore.tablePrefix", configuration.JobStore.TablePrefix},
            {"quartz.jobStore.driverDelegateType", configuration.JobStore.DriverDelegateType},
            {"quartz.jobStore.dataSource", configuration.JobStore.DataSource},
            {$"quartz.dataSource.{configuration.JobStore.DataSource}.connectionString", configuration.DataSource.ConnectionString},
            {$"quartz.dataSource.{configuration.JobStore.DataSource}.provider", configuration.DataSource.Provider},
            {"quartz.serializer.type", configuration.Serializer.Type}
        };
    }
}