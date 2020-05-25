﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfLittleComponents.Models
{
    public class TemperatureAndHumidity
    {
        public int Id { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }

        public TemperatureAndHumidity()
        {
        }
    }
}
