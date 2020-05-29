using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LordOfLittleComponents.Models;


namespace LordOfLittleComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly LordOfLittleComponentsContext _context;
        private SerialPortConnector _serialPortConnector;

        public HomeController(LordOfLittleComponentsContext context)
        {
            _context = context;
            _serialPortConnector = new SerialPortConnector();
        }

        public IActionResult Index()
        {
            var data = ShowTemperatureAndHumidityData();

            var component_1 = _context.Commands.FirstOrDefault(x => x.Id == 1).Status_Enum;
            var component_2 = _context.Commands.FirstOrDefault(x => x.Id == 2).Status_Enum;
            var component_3 = _context.Commands.FirstOrDefault(x => x.Id == 3).Status_Enum;
            var component_4 = _context.Commands.FirstOrDefault(x => x.Id == 4).Status_Enum;

            data.Status1 = component_1;
            data.Status2 = component_2;
            data.Status3 = component_3;
            data.Status4 = component_4;
            

            return View(data);
        }

        private EnvironmentDataViewModel ShowTemperatureAndHumidityData()
        {
            var data = _context.TemperatureAndHumidity.LastOrDefault();
            EnvironmentDataViewModel viewModel = new EnvironmentDataViewModel();

            try
            {
                viewModel.Id = data.Id;
                viewModel.Temperature = data.Temperature + " °C";
                viewModel.Humidity = data.Humidity + " %";
            }

            catch (NullReferenceException)
            {
                viewModel.Id = 0;
                viewModel.Temperature = "Unfortunately, no data was found in database.";
                viewModel.Humidity = "Unfortunately, no data was found in database.";
            }

            return viewModel;
        }

        public object RefreshTemperatureAndHumidityData()
        {
            var data = ShowTemperatureAndHumidityData();

            return PartialView("_SensorData", data);
        }

        public string SendCommand(int id, string command)
        {

            var component = _context.Commands.First(x => x.Id == id);
            if (command == "On")
            {
                component.Status = component.On;
                component.Status_Enum = Models.Enums.StatusEnum.On;
            }
            else
            {
                component.Status = component.Off;
                component.Status_Enum = Models.Enums.StatusEnum.Off;
            }
            
            _context.Commands.Update(component);
            _context.SaveChanges();

            return command;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
