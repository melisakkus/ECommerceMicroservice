﻿namespace ECommerce.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set; }
    }
}
