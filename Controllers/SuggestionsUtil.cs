using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApplication
{
    class SuggestionsUtil : ISuggestionsUtil
    {
        private IAPIHelper _apihelper;
        public SuggestionsUtil()
        {
            _apihelper = new APIHelper(new ConsoleLogger());
        }

        public async Task<List<Suggestion>> GetSuggestions(string location)
        {
            List<Suggestion> suggestionsArray = await _apihelper.GetData<List<Suggestion>>($"/locations/v1/cities/autocomplete?apikey=liWvgCeRiWGoGrGaWFROTkoSNoUHeXu4&q={location}");
            
            return suggestionsArray;
        }
    }
}
