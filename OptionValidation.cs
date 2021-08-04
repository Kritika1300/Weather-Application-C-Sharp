using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WeatherApplication
{
    class OptionValidation : IValidation<int>
    {
        public bool IsValid(int value)
        {
            return ContainsNumbersOnly(value);
        }
        public bool IsValid(int value, List<Suggestion> suggestionsArray)
        {
            return value < Math.Min(10, suggestionsArray.Count);

        }
        private bool ContainsNumbersOnly(int value)
        {
            Regex regex = new Regex("^[0-9]$");
            string str = value.ToString();
            return regex.IsMatch(str);
        }
    
    }
}
