
namespace WeatherApplication
{
    class Suggestion
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public RegionInfo Country { get; set; }
        public RegionInfo AdministrativeArea { get; set; }

    }
    class RegionInfo 
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }

    }

}
