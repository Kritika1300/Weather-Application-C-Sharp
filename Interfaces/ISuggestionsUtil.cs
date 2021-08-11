using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApplication
{
    interface ISuggestionsUtil
    {
        public Task<List<Suggestion>> GetSuggestions(string location);
    }
}
