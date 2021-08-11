
namespace WeatherApplication
{
    class Weather
    {
        public string WeatherText { get; set; }
        public Temperature temperature { get; set; }
        public TemperatureSummary temperatureSummary { get; set; }
        public string RelativeHumidity { get; set; }
        public bool IsDayTime { get; set; }

    }

    class Temperature
    {
        public Metric metric { get; set; }
    }

    class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
    class TemperatureSummary
    {
        public Past24HourRange past24HourRange { get; set; }

    }

    class Past24HourRange
    {
        public Minimum minimum { get; set; }
        public Maximum maximum { get; set; }

    }

    class Minimum 
    {
        public Metric metric { get; set; }
    }

    class Maximum
    {
        public Metric metric { get; set; }
    }

}
