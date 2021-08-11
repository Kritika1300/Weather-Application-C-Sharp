
namespace WeatherApplication
{
    static class TemperatureConversion
    {
        public static double CelciusToFarenheit(double celciusTemp)
        {
            return 1.8 * celciusTemp + 32;
        }
        public static double CelciusToKelvin(double celciusTemp)
        {
            return celciusTemp + 273.15;
        }

        public static double CelciusToRankine(double celciusTemp)
        {
            return (celciusTemp + 273.15) * 1.8;
        }
        public static double CelciusToNewton(double celciusTemp)
        {
            return celciusTemp * 0.33000;
        }
    }
}
