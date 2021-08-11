using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApplication
{
    class APIHelper : IAPIHelper
    {
        private static HttpClient httpClient;
        private ILogger _logger;
        public APIHelper(ILogger logger)
        {
            _logger = logger;
        }
        static APIHelper()
        {
           httpClient = new HttpClient();
           httpClient.BaseAddress = new Uri("http://dataservice.accuweather.com");
        }
        public async Task<T> GetData<T>(string endpoint)
        {
            T results = default(T);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    _logger.LogError("Error fetching data from the API");
                    Environment.Exit(-1);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Kindly check your network connection." + ex.Message);
                Environment.Exit(-1);
            }
        
            return results;

        }
    }
}
