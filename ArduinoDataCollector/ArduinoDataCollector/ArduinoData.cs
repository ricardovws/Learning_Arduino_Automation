using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;
using System.IO.Ports;
using System.IO;
using MySql.Data.MySqlClient;

namespace ArduinoDataCollector
{
    public class ArduinoData
    {
        readonly Timer _timer;
        private readonly int _baudRate = 9600;
        private readonly string _portName = "COM3";

        //AppDBContext db = new AppDBContext();


        public ArduinoData()
        {
            _timer = new Timer(3000) { AutoReset = true };

            _timer.Elapsed += (sender, eventArgs) =>

            Console.WriteLine("It's {0} and this service is working!", DateTime.Now);

            _timer.Elapsed += (sender, eventArgs) =>

            DataFromArduino();
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }

        public void DataFromArduino()
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {
                serialPort.Open();

                int id = 264;

                while (true)
                {
                    //Here he takes the data that comes from Arduino serial port
                   
                    string[] _data_ = new string[] { serialPort.ReadLine() };

                    //*//*//

                    string data = serialPort.ReadLine();

                    string[] dataToSplit = data.Split(',');

                    string temp = null;
                    string hum = null;

                    try
                    {
                        temp = dataToSplit[0];
                        hum = dataToSplit[1];
                    }
                    
                    catch(IndexOutOfRangeException _e)
                    {
                        Console.WriteLine("Aiaiaiai! - " + _e.Message);
                        ;
                    }


                    SaveInDB(id, temp, hum);

                    id++;

                    //Here it reads data from DB and write in Arduino:

                   
                    MySqlConnection connection;
                    string connectionString = "server=localhost;uid=root;pwd=1234567;database=lordoflittlecomponentsappdb";

                    

                    try
                    {
                        connection = new MySqlConnection();
                        connection.ConnectionString = connectionString;
                        connection.Open();

                        string query = "SELECT * FROM commands";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            var reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                
                                int status_ = (int)reader["Status"];

                                Console.WriteLine("--------" + status_);

                                serialPort.Write(status_.ToString());
                            }
                            
                        }

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("Oupsi! We have an error here! - " + e.Message);
                    }

                 
                    //******//

                    //Here it generates a .txt file
                    string fileName = "arduinoData";
                    string fileExtension = "txt";
                    string filePath = @"C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\ArduinoDataCollector\";
                    File.AppendAllLines(filePath + fileName + "." + fileExtension, _data_);
                    //************************************//

                }

            }
        }

        private void SaveInDB(int id, string temperature, string humidity)
        {
            DataFromArduinoToDB data = new DataFromArduinoToDB();
            data.Id = id;
            data.Temperature = temperature;
            data.Humidity = humidity;

            MySqlConnection connection;
            string connectionString = "server=localhost;uid=root;pwd=1234567;database=lordoflittlecomponentsappdb";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "INSERT INTO temperatureandhumidity (Id, Temperature, Humidity) VALUES (@Id, @Temperature, @Humidity)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", data.Id);
                    command.Parameters.AddWithValue("@Temperature", data.Temperature);
                    command.Parameters.AddWithValue("@Humidity", data.Humidity);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Salvou no banco, home!");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Deu erro! - " + e.Message);
            }
            
        }
    }
}
