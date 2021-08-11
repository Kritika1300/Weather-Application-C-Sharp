using System.Threading.Tasks;

namespace WeatherApplication
{
    interface IAPIHelper
    {
        Task<T> GetData<T>(string endpoint);
    }
}
