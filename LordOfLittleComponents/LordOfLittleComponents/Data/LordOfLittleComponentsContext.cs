using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LordOfLittleComponents.Models;

namespace LordOfLittleComponents.Models
{
    public class LordOfLittleComponentsContext : DbContext
    {
      
        public LordOfLittleComponentsContext (DbContextOptions<LordOfLittleComponentsContext> options)
            : base(options)
        {
        }

        public DbSet<TemperatureAndHumidity> TemperatureAndHumidity { get; set; }

        public DbSet<Commands> Commands { get; set; }
    }
}
