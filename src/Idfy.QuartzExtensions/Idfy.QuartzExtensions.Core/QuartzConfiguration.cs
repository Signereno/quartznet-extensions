using System;

namespace Idfy.QuartzExtensions.Core
{
    public class QuartzConfiguration
    {
        public QuartzConfiguration(string instanceName, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(instanceName))
            {
                throw new ArgumentNullException(nameof(instanceName));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            
            Scheduler = new QuartzSchedulerConfiguration()
            {
                InstanceName = instanceName
            };
            
            ThreadPool = new QuartzThreadPoolConfiguration();
            
            JobStore = new QuartzJobStoreConfiguration();
            
            DataSource = new QuartzDataSourceConfiguration()
            {
                ConnectionString = connectionString
            };
            
            Serializer = new QuartzSerializerConfiguration();
        }
        
        public QuartzSchedulerConfiguration Scheduler { get; set; }
        
        public QuartzThreadPoolConfiguration ThreadPool { get; set; }
        
        public QuartzJobStoreConfiguration JobStore { get; set; }
        
        public QuartzDataSourceConfiguration DataSource { get; set; }
        
        public QuartzSerializerConfiguration Serializer { get; set; }
    }

    public class QuartzSchedulerConfiguration
    {
        /// <summary>
        /// Can be any string, and the value has no meaning to the scheduler itself - but rather serves as a mechanism for
        /// client code to distinguish schedulers when multiple instances are used within the same program.
        /// If you are using the clustering features, you must use the same name for every instance in the cluster that is ‘logically’ the same Scheduler.
        /// </summary>
        public string InstanceName { get; set; }
        
        /// <summary>
        /// Can be any string, but must be unique for all schedulers working as if they are the same ‘logical’ Scheduler within a cluster.
        /// You may use the value “AUTO” as the instanceId if you wish the Id to be generated for you. Or the value “SYS_PROP” if you want
        /// the value to come from the system property “quartz.scheduler.instanceId”.
        /// The default value is "AUTO".
        /// </summary>
        public string InstanceId { get; set; } = "AUTO";
    }

    public class QuartzThreadPoolConfiguration
    {
        /// <summary>
        /// Is the name of the ThreadPool implementation you wish to use. The threadpool that ships with Quartz is “Quartz.Simpl.SimpleThreadPool”,
        /// and should meet the needs of nearly every user. It has very simple behavior and is very well tested. It provides a fixed-size pool of threads
        /// that ‘live’ the lifetime of the Scheduler.
        /// The default value is "Quartz.Simpl.SimpleThreadPool, Quartz".
        /// </summary>
        public string Type { get; set; } = "Quartz.Simpl.SimpleThreadPool, Quartz";

        /// <summary>
        /// Can be any positive integer, although you should realize that only numbers between 1 and 100 are very practical.
        /// This is the number of threads that are available for concurrent execution of jobs. If you only have a few jobs that fire a few times a day,
        /// then 1 thread is plenty! If you have tens of thousands of jobs, with many firing every minute, then you probably want a thread count more like
        /// 50 or 100 (this highly depends on the nature of the work that your jobs perform, and your systems resources!).
        /// <para/>
        /// <para/>
        /// The default value is 1.
        /// </summary>
        public int ThreadCount { get; set; } = 1;
    }

    public class QuartzJobStoreConfiguration
    {
        /// <summary>
        /// The “use properties” flag instructs the job store that all values in JobDataMaps will be Strings, and therefore can be stored as name-value pairs,
        /// rather than storing more complex objects in their serialized form in the BLOB column.
        /// This is can be handy, as you avoid the class versioning issues that can arise from serializing your non-String classes into a BLOB.
        /// <para/>
        /// <para/>
        /// The default value is "true".
        /// </summary>
        public bool UseProperties { get; set; } = true;

        /// <summary>
        /// Set to “true” in order to turn on clustering features. This property must be set to “true” if you are having multiple instances of Quartz
        /// use the same set of database tables… otherwise you will experience havoc. See the configuration docs for clustering for more information.
        /// <para/>
        /// <para/>
        /// The default value is "true".
        /// </summary>
        public bool Clustered { get; set; } = true;

        /// <summary>
        /// The the number of milliseconds the scheduler will ‘tolerate’ a trigger to pass its next-fire-time by, before being considered “misfired”.
        /// <para/>
        /// <para/>
        /// The default value is 60000 (60 seconds).
        /// </summary>
        public int MisfireThreshhold { get; set; } = 60000;

        /// <summary>
        /// The IJobStore implementation for the Quartz scheduler. Is responsible for keeping track of all the "work data" that you give to the scheduler:
        /// jobs, triggers, calendars, etc.
        /// <para/>
        /// <para/>
        /// Default value is "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz".
        /// </summary>
        public string Type { get; set; } = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";

        /// <summary>
        /// The “table prefix” property is a string equal to the prefix given to Quartz’s tables that were created in your database.
        /// You can have multiple sets of Quartz’s tables within the same database if they use different table prefixes.
        /// <para/>
        /// <para/>
        /// The default value is "QRTZ_".
        /// </summary>
        public string TablePrefix { get; set; } = "QRTZ_";

        /// <summary>
        /// Driver delegates understand the particular ‘dialects’ of varies database systems. Possible choices include:
        /// <para/>
        /// "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz" (for MSSQL Server)
        /// </summary>
        public string DriverDelegateType { get; set; }

        /// <summary>
        /// The value of this property must be the name of one the DataSources defined in the configuration properties file.
        /// <para/>
        /// <para/>
        /// Default value is "myDS".
        /// </summary>
        public string DataSource { get; set; } = "myDS";
    }

    public class QuartzDataSourceConfiguration
    {
        /// <summary>
        /// The data source connection string information.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The data source database provider.
        /// </summary>
        public string Provider { get; set; }
    }

    public class QuartzSerializerConfiguration
    {
        /// <summary>
        /// State whether you want to use binary or json serialization if you are using persistent job store.
        /// Possible values:
        /// <para/>
        /// "json", "binary"
        /// </summary>
        public string Type { get; set; } = "json";
    }
}
