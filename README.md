# quartznet-extensions

Provides helper methods for configuring [Quartz.NET](https://github.com/quartznet/quartznet) scheduler with a persistent JobStore. 

## Usage

Below are some examples on how to create a new scheduler. Note that `InstanceName` must be a unique identifier for your scheduler and is used to distinguish schedulers that are using the same JobStore.

See [Quartz Configuration Reference](http://www.quartz-scheduler.org/documentation/quartz-2.x/configuration/) for information about the available configuration properties.

Database tables are not created automatically. The required tables must first be created by running the provided script.

### SqlServer

Database script: https://github.com/quartznet/quartznet/blob/master/database/tables/tables_sqlServer.sql

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

### PostgreSQL

Database script: https://github.com/quartznet/quartznet/blob/master/database/tables/tables_postgres.sql

With default configuration:

```csharp
IScheduler scheduler = await PostgreSqlSchedulerFactory.GetDefaultScheduler("InstanceName", "ConnectionString");
await scheduler.Start();
```

With custom configuration:
```csharp
var config = new QuartzPostgreSqlConfiguration("InstanceName", "ConnectionString") {
    ThreadPool = new QuartzThreadPoolConfiguration()
    {
      ThreadCount = 10
    }
};

IScheduler scheduler = await PostgreSqlSchedulerFactory.GetDefaultScheduler(config);
await scheduler.Start();
```
