using System;
using System.Collections.Generic;

namespace WeatherApplication
{
    class UpdateUI : IUpdateUI
    {
        private ILogger _logger;
        public UpdateUI(ILogger logger)
        {
            _logger = logger;
        }
        public void WelcomeScreen()
        {
            _logger.LogMessage("");
            _logger.LogMessage("Welcome to Weather App");
            _logger.LogMessage("Enter a location : ");
     
        }
        public void SuggestionsMenu(List<Suggestion> suggestions)
        {
            _logger.LogMessage("");
            _logger.LogMessage("Please select from the following : ");
            for (int i = 0; i < Math.Min(10, suggestions.Count); i++)
            {
                _logger.LogMessage((i + 1) + ". " + suggestions[i].LocalizedName + ", " + suggestions[i].AdministrativeArea.LocalizedName + ", " + suggestions[i].Country.LocalizedName);
            }
            _logger.LogMessage("");
        }

        public void PrintWeather(Weather weather)
        {
            _logger.LogMessage("");
            _logger.LogMessage("Temperature : " + weather.temperature.metric.Value + " °" + weather.temperature.metric.Unit);
            _logger.LogMessage(weather.WeatherText);
            _logger.LogMessage("Relative Humidity : " + weather.RelativeHumidity);
            _logger.LogMessage("Temperature Summary for past 24 hours :");
            _logger.LogMessage("Maximum Temperature :" + weather.temperatureSummary.past24HourRange.maximum.metric.Value + " °" + weather.temperatureSummary.past24HourRange.maximum.metric.Unit);
            _logger.LogMessage("Minimum Temperature :" + weather.temperatureSummary.past24HourRange.minimum.metric.Value + " °" + weather.temperatureSummary.past24HourRange.minimum.metric.Unit);
            _logger.LogMessage("");
        }

        public void UtilitiesMenu()
        {
            _logger.LogMessage("");
            _logger.LogMessage("Press Q to quit");
            _logger.LogMessage("Press S to get weather updates for another location");
            _logger.LogMessage("Press V to view temperature in other units");
            _logger.LogMessage("");
        }

        public void PrintConvertedTemperature(Weather weather)
        {
            _logger.LogMessage("");
            _logger.LogMessage("In Farenheit : " + TemperatureConversion.CelciusToFarenheit(weather.temperature.metric.Value) + " °F");
            _logger.LogMessage("In Kelvin : " + TemperatureConversion.CelciusToKelvin(weather.temperature.metric.Value) + " °K");
            _logger.LogMessage("In Rankine : " + TemperatureConversion.CelciusToRankine(weather.temperature.metric.Value) + " °R");
            _logger.LogMessage("In Newton : " + TemperatureConversion.CelciusToNewton(weather.temperature.metric.Value) + " °N");
            _logger.LogMessage("");
        }
        public void ExitScreen()
        {
            _logger.LogMessage("");
            _logger.LogMessage("Thankyou for using my application");
            _logger.LogMessage("");

        }

        public void ClearScreen()
        {
            Console.Clear();
        }


    }
}
