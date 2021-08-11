using System;

namespace WeatherApplication
{
    class ConsoleLogger : ILogger
    {
        public void LogError(string error)
        {
            Console.WriteLine("************************** ERROR **************************");
            Console.WriteLine(error);
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
