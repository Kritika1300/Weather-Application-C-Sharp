using System.Threading.Tasks;

namespace WeatherApplication
{
    interface IWeatherUtil
    {
        public Task<Weather> GetWeatherInfo(string locationKey);
    }
}
