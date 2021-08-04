

namespace WeatherApplication
{
    interface IAPIHelper
    {
        T GetData<T>(string endpoint);
    }
}
