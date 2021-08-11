using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WeatherApplication
{
    class LocationValidation<T> : IValidation<T>
    {
        public bool IsValid(T value)
        {
            return ContainsAlphabetsOnly(value) && IsNotEmpty(value);
        }

        public bool IsValid(List<Suggestion> suggestions)
        {
            return suggestions.Count != 0;
        }

        bool ContainsAlphabetsOnly(T value)
        {
            Regex regex = new Regex("^[a-zA-Z '-]+$");
            return regex.IsMatch(value.ToString());
          
        }

        bool IsNotEmpty(T value)
        {
            return value.ToString().Length != 0;
        }
    }
}
