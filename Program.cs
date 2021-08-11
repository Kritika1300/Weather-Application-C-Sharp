using System.Threading.Tasks;
using WeatherApplication.Controllers;

namespace WeatherApplication
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            FileLogger fileLogger = new FileLogger();
            UpdateUI updateUI = new UpdateUI(consoleLogger);
            UserInput userInput = new UserInput();
            WeatherApplication application = new WeatherApplication(fileLogger,updateUI,userInput);
            await application.Start();
        }
    }
}
