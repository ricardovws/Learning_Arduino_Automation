using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;

namespace LordOfLittleComponents.Models
{
    public class SerialPortConnector
    {
        private readonly int _baudRate = 9600;
        private readonly string _portName = "COM3";


        public void Send(string command)
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {
                serialPort.Open();
                serialPort.Write(command);
            }
        }

     
        public List<TemperatureAndHumidity> ShowTemperatureAndHumidity()
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {
                List<TemperatureAndHumidity> data = new List<TemperatureAndHumidity>();
                int times = 1;

                serialPort.Open();

                while (true)
                {

                    //enquanto a porta estiver aberta, vai inserir o numero 
                    //vindo da porta serial dentro da variável "number"

                    string temperature = serialPort.ReadLine();

                    string[] dataToSplit = temperature.Split(',');

                    string temp = null;
                    string hum = null;

                    try
                    {
                          temp = dataToSplit[0];
                          hum = dataToSplit[1];
                    }

                    catch(IndexOutOfRangeException)
                    {
                        ;
                    }

                    TemperatureAndHumidity temperatureAndHumidity = new TemperatureAndHumidity();

                    temperatureAndHumidity.Temperature = temp;
                    temperatureAndHumidity.Humidity = hum;

                    //string new_temperature = temperature.Substring(0, temperature.Length - 1);
                    data.Add(temperatureAndHumidity);
                    times++;

                    if (times > 20)
                    {
                        break;
                    }
                }

                return data;
            }

        }

    }
}
