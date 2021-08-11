using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApplication
{
    class WeatherUtil : IWeatherUtil
    {
        private IAPIHelper _apihelper;
        public WeatherUtil()
        {
            _apihelper = new APIHelper(new ConsoleLogger());
        }

        public async Task<Weather> GetWeatherInfo(string locationKey)
        {
           List<Weather> weatherArray = await _apihelper.GetData<List<Weather>>($"/currentconditions/v1/{locationKey}?apikey=liWvgCeRiWGoGrGaWFROTkoSNoUHeXu4&details=true");
           return weatherArray[0];
        }
    }
}
