﻿namespace OnlineAuction.Sourcing.Settings
{
    public class SourcingDatabaseSettings : ISourcingDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
