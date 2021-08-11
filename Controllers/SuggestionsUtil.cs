using System.Collections.Generic;

namespace WeatherApplication
{
    class SuggestionsUtil : ISuggestionsUtil
    {
        private IAPIHelper _apihelper;
        public SuggestionsUtil()
        {
            _apihelper = new APIHelper(new ConsoleLogger());
        }

        public List<Suggestion> GetSuggestions(string location)
        {
            List<Suggestion> suggestionsArray = _apihelper.GetData<List<Suggestion>>($"/locations/v1/cities/autocomplete?apikey=Lgv6KAAwYhtu6CrUclX2uSHhenZMfdth&q={location}");
            
            return suggestionsArray;
        }
    }
}
