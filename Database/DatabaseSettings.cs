using System;

namespace backend.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public DatabaseSettings()
        {
            this.DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            this.UsersCollectionName = Environment.GetEnvironmentVariable("DATABASE_COLLECTION_NAME");
            this.ConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        }

        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}