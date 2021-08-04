using System.Collections.Generic;

namespace WeatherApplication
{
    class WeatherUtil : IWeatherUtil
    {
        private IAPIHelper _apihelper;
        public WeatherUtil()
        {
            _apihelper = new APIHelper(new ConsoleLogger());
        }

        public Weather GetWeatherInfo(string locationKey)
        {
           List<Weather> weatherArray = _apihelper.GetData<List<Weather>>($"/currentconditions/v1/{locationKey}?apikey=wEjT789qThjGyepa8cOw6f5ZKTwvZtqG&details=true");
           return weatherArray[0];
        }
    }
}
