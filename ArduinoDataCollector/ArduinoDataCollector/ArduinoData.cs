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

        MySqlConnection connection = null;
        string connectionString = "server=localhost;uid=root;pwd=1234567;database=lordoflittlecomponentsappdb";

        int id = 1;

        public void DataFromArduino()
        {
            using (var serialPort = new SerialPort(_portName, _baudRate))
            {
                
                serialPort.Open();

                while (true)
                {
                    //Here he takes the data that comes from Arduino serial port
                   
                    string data = serialPort.ReadLine();
                    

                    //Preparing data to keep working
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


                    //Here it reads data from Arduino serial port and write in DB:
                    SaveInDB(id, temp, hum, connection, connectionString);

                    //Refresh Id
                    id++;

                    //Here it reads data from DB and write in Arduino:
                    OrderToArduino(connection, connectionString, serialPort);


                    //Here it generates a .txt file log just to check if it´s working 
                    string[] _data_ = new string[] { "Temperature and Humidity are, respectively: " + data + ", and you can check all the other data out in database!!!"};
                    string fileName = "arduinoData";
                    string fileExtension = "txt";
                    string filePath = @"C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\ArduinoDataCollector\";
                    File.AppendAllLines(filePath + fileName + "." + fileExtension, _data_);
                    //************************************//

                }

            }
        }

        private void DBConnectionHelper()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        private void GetLastId()
        {
            DBConnectionHelper();

            string query = "SELECT MAX(Id) FROM temperatureandhumidity";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                var newId = (int)command.ExecuteScalar();

                id = newId;

            }
        }

        private void OrderToArduino(MySqlConnection connection, string connectionString, SerialPort serialPort)
        {
            try
            {
                DBConnectionHelper();

                string query = "SELECT * FROM commands";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        int status_ = (int)reader["Status"];
                        int status_enum = (int)reader["Status_Enum"];
                        string Status_To_Print = null;

                        if(status_enum == 0)
                        {
                            Status_To_Print = "Off";
                        }
                        else
                        {
                            Status_To_Print = "On";
                        }

                        Console.WriteLine("Id: "+id+" is " + Status_To_Print);

                        serialPort.Write(status_.ToString());
                    }

                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Oupsi! We have an error here! - " + e.Message);
            }

        }

        private void SaveInDB(int id, string temperature, string humidity, MySqlConnection connection, string connectionString)
        {
            DataFromArduinoToDB data = new DataFromArduinoToDB();
            data.Id = id;
            data.Temperature = temperature;
            data.Humidity = humidity;

            try
            {
                DBConnectionHelper();

                string query = "INSERT INTO temperatureandhumidity (Id, Temperature, Humidity) VALUES (@Id, @Temperature, @Humidity)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", data.Id);
                    command.Parameters.AddWithValue("@Temperature", data.Temperature);
                    command.Parameters.AddWithValue("@Humidity", data.Humidity);

                    command.ExecuteNonQuery();

                    Console.WriteLine("It has been saved in database!");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Ouups! - " + e.Message);
                
                //If this primary key already exists, refresh the id:
                GetLastId();
            }
            
        }
    }
}
