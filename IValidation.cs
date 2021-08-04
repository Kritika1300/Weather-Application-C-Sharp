
namespace WeatherApplication
{
    interface IValidation<T>
    {
        bool IsValid(T value);
    }
}
