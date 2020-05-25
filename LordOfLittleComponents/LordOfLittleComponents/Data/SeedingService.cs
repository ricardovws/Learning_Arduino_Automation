using LordOfLittleComponents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfLittleComponents.Data
{
    public class SeedingService
    {
        private readonly LordOfLittleComponentsContext _context;

        public SeedingService(LordOfLittleComponentsContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(
                //_context.Commands.Any()
                //||
                _context.TemperatureAndHumidity.Any()
                )
            {
                return; //DB has been seeded.
            }


            Commands com1 = new Commands
            {
                Id = 1,
                ComponentName = "White LED",
                On = 1,
                Off = 2,
                Status = 2
            };

            Commands com2 = new Commands
            {
                Id = 2,
                ComponentName = "Yellow LED",
                On = 3,
                Off = 4,
                Status = 4
            };

            Commands com3 = new Commands
            {
                Id = 3,
                ComponentName = "Red LED",
                On = 5,
                Off = 6,
                Status = 6
            };

            Commands com4 = new Commands
            {
                Id = 4,
                ComponentName = "Green LED",
                On = 7,
                Off = 8,
                Status = 8
            };

            _context.AddRange(com1, com2, com3, com4);
            _context.SaveChanges();

        }


       

    }
}
