using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoDataCollector
{
    class AppDBContext:DbContext
    {
        public DbSet<DataFromArduinoToDB> dataFromArduinoToDB { get; set; }
    }
}
