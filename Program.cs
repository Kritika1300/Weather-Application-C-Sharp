
namespace WeatherApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            UpdateUI updateUI = new UpdateUI(consoleLogger);
            UserInput userInput = new UserInput();
            WeatherApplication application = new WeatherApplication(consoleLogger,updateUI,userInput);
            application.Start();
        }
    }
}
