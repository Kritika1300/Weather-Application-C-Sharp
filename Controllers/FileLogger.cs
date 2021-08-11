using System;
using System.IO;

namespace WeatherApplication.Controllers
{
    class FileLogger : ILogger
    {
        public void LogError(string message)
        {

            using (StreamWriter sw = File.AppendText(@"./ErrorLog.txt"))
            {
                sw.WriteLine(message + " " + DateTime.Now.ToString());
                sw.WriteLine();
            }


        }
        public void LogMessage(string message)
        {
            using (StreamWriter sw = File.AppendText(@"./MessageLog.txt"))
            {
                sw.WriteLine(message + " " + DateTime.Now.ToString());

            }

        }
    }
}
