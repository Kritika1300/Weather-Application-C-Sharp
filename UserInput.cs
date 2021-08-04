using System;

namespace WeatherApplication
{
    class UserInput : IUserInput
    {
        public string GetLocation()
        {
            return Console.ReadLine().Trim();
        }
        public int GetSelectedSuggestion()
        {
            int result;
            int.TryParse(Console.ReadLine().Trim(), out result);
            return result;
        }
        public string GetSelectedUtility()
        {
            return Console.ReadLine().Trim();
        }
    }
}
