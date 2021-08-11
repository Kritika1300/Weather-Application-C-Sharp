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

        public async Task Start()
        {

            welcomescreen: _updateUI.WelcomeScreen();

            string location = _userInput.GetLocation();
            LocationValidation<string> locationValidation = new LocationValidation<string>();

            if (!locationValidation.IsValid(location))
            {
                _updateUI.ClearScreen();
                _logger.LogError("Location cannot be empty and should contain only alphabets.Try again !");
                goto welcomescreen;
            }

            _updateUI.ClearScreen();

            ISuggestionsUtil suggestionsUtil = new SuggestionsUtil();
            List<Suggestion> suggestions = await suggestionsUtil.GetSuggestions(location);

            if (!locationValidation.IsValid(suggestions))
            {
                _updateUI.ClearScreen();
                _logger.LogError("No results found for this location. Try another?");
                goto welcomescreen;
            }

            suggestionsMenu: _updateUI.SuggestionsMenu(suggestions);

            int selectedSuggestion = _userInput.GetSelectedSuggestion() - 1;
            OptionValidation optionValidation = new OptionValidation();

            if (!optionValidation.IsValid(selectedSuggestion) || !optionValidation.IsValid(selectedSuggestion,suggestions))
            {
                _updateUI.ClearScreen();
                _logger.LogError("Please make a valid selection");
                goto suggestionsMenu;
            }

            _updateUI.ClearScreen();

            IWeatherUtil weatherUtil = new WeatherUtil();
            Weather weather = await weatherUtil.GetWeatherInfo(suggestions[selectedSuggestion].Key);
            utilitiesMenu: _updateUI.PrintWeather(weather);

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
                    goto utilitiesMenu;
            }
        }
    }
}
    