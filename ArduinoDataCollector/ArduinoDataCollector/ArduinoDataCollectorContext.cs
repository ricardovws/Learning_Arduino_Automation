using System;
using System.Data.Entity;

namespace ArduinoDataCollector
{
    public class ArduinoDataCollectorContext : DbContext
    {
        public DbSet<DataFromArduinoToDB> DataFromArduinoToDB { get; set; }
    }
}