﻿using System;
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

        //public HomeController()
        //{
        //    _serialPortConnector = new SerialPortConnector();
        //}

        public IActionResult Index()
        {
            var data = ShowTemperatureAndHumidityData();

            data.Status = "Olha o bicho vindo, home!";
            
            return View(data);
        }

        private EnvironmentDataViewModel ShowTemperatureAndHumidityData()
        {
            var data = _context.TemperatureAndHumidity.LastOrDefault();
            EnvironmentDataViewModel viewModel = new EnvironmentDataViewModel();
            viewModel.Id = data.Id;
            viewModel.Temperature = data.Temperature;
            viewModel.Humidity = data.Humidity;

            return viewModel;
        }

        public object RefreshTemperatureAndHumidityData()
        {
            var data = ShowTemperatureAndHumidityData();

            //var data = _context.TemperatureAndHumidity.FirstOrDefault();
            //EnvironmentDataViewModel viewModel = new EnvironmentDataViewModel();
            //viewModel.Id = data.Id;
            //viewModel.Temperature = data.Temperature;
            //viewModel.Humidity = data.Humidity;

            return PartialView("_SensorData", data);
        }

        //public void On_Command(int id)
        //{
        //    var component = _context.Commands.First(x => x.Id == id);
        //    component.Status = component.On;
        //    SendCommand(component);
        //}

        //public void Off_Command(int id)
        //{
        //    var component = _context.Commands.First(x => x.Id == id);
        //    component.Status = component.On;
        //    SendCommand(component);
        //}

        public string SendCommand(int id, string command)
        {

            var component = _context.Commands.First(x => x.Id == id);
            if (command == "Ligar")
            {
                component.Status = component.On;
            }
            else
            {
                component.Status = component.Off;
            }
            
            _context.Commands.Update(component);
            _context.SaveChanges();

            return command;
        }


        public IActionResult Send_turnOn()
        {
            var command = 1;
            _serialPortConnector.Send(command.ToString());
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Send_turnOff()
        {
            var command = 0;
            _serialPortConnector.Send(command.ToString());
            return RedirectToAction(nameof(Index));
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