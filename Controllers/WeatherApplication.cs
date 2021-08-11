using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApplication
{
    class WeatherApplication
    {
        private ILogger _logger;
        private IUpdateUI _updateUI;
        private IUserInput _userInput;

        public WeatherApplication(ILogger logger, IUpdateUI updateUI, IUserInput userInput)
        {
            _logger = logger;
            _updateUI = updateUI;
            _userInput = userInput;
        }
        public async Task<List<Suggestion>> Welcome()
        {
            _updateUI.WelcomeScreen();

            string location = _userInput.GetLocation();
            LocationValidation<string> locationValidation = new LocationValidation<string>();

            if (!locationValidation.IsValid(location))
            {
                _updateUI.ClearScreen();
                _logger.LogError("Location cannot be empty and should contain only alphabets.Try again !");
                return await Welcome();
            }

            _updateUI.ClearScreen();

            ISuggestionsUtil suggestionsUtil = new SuggestionsUtil();
            List<Suggestion> suggestions = await suggestionsUtil.GetSuggestions(location);

            if (!locationValidation.IsValid(suggestions))
            {
                _updateUI.ClearScreen();
                _logger.LogError("No results found for this location. Try another?");
                return await Welcome();

            }

            return suggestions;
        }

        public int RenderSuggestionsMenu(List<Suggestion> suggestions)
        {
            _updateUI.SuggestionsMenu(suggestions);

            int selectedSuggestion = _userInput.GetSelectedSuggestion() - 1;
            OptionValidation optionValidation = new OptionValidation();

            if (!optionValidation.IsValid(selectedSuggestion) || !optionValidation.IsValid(selectedSuggestion, suggestions))
            {
                _updateUI.ClearScreen();
                _logger.LogError("Please make a valid selection");
                return RenderSuggestionsMenu(suggestions);
            }

            return selectedSuggestion;
        }

        public async Task RenderWeather(Weather weather)
        {
            _updateUI.ClearScreen();

            _updateUI.PrintWeather(weather);
            await RenderUtilitiesMenu(weather);

        }

        public async Task RenderUtilitiesMenu(Weather weather)
        {
            _updateUI.UtilitiesMenu();

            string selectedUtility = _userInput.GetSelectedUtility();

            switch (selectedUtility)
            {
                case "Q":
                case "q":
                    _updateUI.ExitScreen();
                    break;

                case "V":
                case "v":
                    _updateUI.PrintConvertedTemperature(weather);
                    _updateUI.ExitScreen();
                    break;

                case "S":
                case "s":
                    _updateUI.ClearScreen();
                    await Start();
                    break;
                default:
                    _updateUI.ClearScreen();
                    _logger.LogError("Invalid Choice.Please try again");
                    await RenderWeather(weather);
                    break;
            }
        }

        public async Task Start()
        {
            List<Suggestion> suggestions = await Welcome();
            int selectedSuggestion = RenderSuggestionsMenu(suggestions);
            IWeatherUtil weatherUtil = new WeatherUtil();
            Weather weather = await weatherUtil.GetWeatherInfo(suggestions[selectedSuggestion].Key);
            await RenderWeather(weather);

        }
    }
}
