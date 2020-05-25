using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfLittleComponents.Models
{
    public class Commands
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public int On { get; set; }
        public int Off { get; set; }
        public int Status { get; set; }
    }
}
