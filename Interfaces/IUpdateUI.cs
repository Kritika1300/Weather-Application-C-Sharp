using System.Collections.Generic;

namespace WeatherApplication
{
    interface IUpdateUI
    {
        void WelcomeScreen();
        void PrintWeather(Weather weather);
        void SuggestionsMenu(List<Suggestion> suggestions);
        void UtilitiesMenu();
        void ExitScreen();
        void ClearScreen();
        void PrintConvertedTemperature(Weather weather);
    }
}
