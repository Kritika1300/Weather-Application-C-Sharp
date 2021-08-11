using System.Threading.Tasks;

namespace WeatherApplication
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            UpdateUI updateUI = new UpdateUI(consoleLogger);
            UserInput userInput = new UserInput();
            WeatherApplication application = new WeatherApplication(consoleLogger,updateUI,userInput);
            await application.Start();
        }
    }
}
