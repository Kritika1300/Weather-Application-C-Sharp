using System.Collections.Generic;

namespace WeatherApplication
{
    interface ISuggestionsUtil
    {
        public List<Suggestion> GetSuggestions(string location);
    }
}
