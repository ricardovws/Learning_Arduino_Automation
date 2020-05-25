using LordOfLittleComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LordOfLittleComponents.Services
{
    public class ConnectionService
    {
        private readonly LordOfLittleComponentsContext _context;

        public ConnectionService(LordOfLittleComponentsContext context)
        {
            _context = context;
        }

        //public void AddNumber(string _number)
        //{
        //    Number number = new Number();
        //    number._Number = _number;
        //    _context.Add(number);
        //    _context.SaveChanges();
        //}
    }
}
