using LordOfLittleComponents.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfLittleComponents.Models
{
    public class EnvironmentDataViewModel
    {
        public int Id { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }

        public StatusEnum Status1 { get; set; }
        public StatusEnum Status2 { get; set; }
        public StatusEnum Status3 { get; set; }
        public StatusEnum Status4 { get; set; }
    }
}
