using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ArduinoDataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                               
            {
                x.Service<ArduinoData>(s =>                                   
                {
                    s.ConstructUsing(name => new ArduinoData());              
                    s.WhenStarted(tc => tc.Start());                       
                    s.WhenStopped(tc => tc.Stop());                       
                });
                x.RunAsLocalSystem();                                     

                x.SetDescription("A service that store data from Arduino to a database.");                
                x.SetDisplayName("Arduino Data Collector");                                
                x.SetServiceName("ArduinoDataCollector");                              
            });                                                            

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());   
            Environment.ExitCode = exitCode;
        }
    }
}
