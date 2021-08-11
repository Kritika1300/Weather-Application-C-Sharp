using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public T GetData<T>(string endpoint)
        {
            T results = default(T);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(endpoint).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
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
