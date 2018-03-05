# quartz-extensions

Provides helper methods for configuring Quartz scheduler with a persistent JobStore. 

## Usage

Below are some examples on how to create a new scheduler. Note that `InstanceName` must be a unique identifier for your scheduler and is used to distinguish schedulers that are using the same JobStore.

See [Quartz Configuration Reference](http://www.quartz-scheduler.org/documentation/quartz-2.x/configuration/) for information about the available configuration properties.

### SqlServer

With default configuration:

```csharp
IScheduler scheduler = await SqlServerSchedulerFactory.GetDefaultScheduler("InstanceName", "ConnectionString");
await scheduler.Start();
```

With custom configuration:
```csharp
var config = new QuartzSqlServerConfiguration("InstanceName", "ConnectionString") {
    ThreadPool = new QuartzThreadPoolConfiguration()
    {
      ThreadCount = 10
    }
};

IScheduler scheduler = await SqlServerSchedulerFactory.GetDefaultScheduler(config);
await scheduler.Start();
```
