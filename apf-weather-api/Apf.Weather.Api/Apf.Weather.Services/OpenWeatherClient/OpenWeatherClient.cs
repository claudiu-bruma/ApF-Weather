using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http; 
using System.Threading.Tasks;
using Apf.Weather.Services.OpenWeatherApiContracts;
using Apf.Weather.Services.OpenWeatherDataAggregator;
using Apf.Weather.Services.Constants;

namespace Apf.Weather.Services.OpenWeatherClient
{
    public class OpenWeatherClient : IOpenWeatherClient
    {

        private readonly HttpClient _client;
        private readonly IOWMAggregator _aggregator;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public OpenWeatherClient(HttpClient httpClient, IConfiguration configuration, IOWMAggregator aggregator)
        {
            httpClient.BaseAddress = new Uri(OWApiConstants.OWApiBaseUrl);

            _client = httpClient;
            _configuration = configuration;
            _apiKey = _configuration[OWApiConstants.OWApiKeyNameConfig];
            _aggregator = aggregator;
        }

        public async Task<IEnumerable<CityDayForcastDto>> Get5DayForecast(string city)
        {
          
            var forecast = await _client.GetStringAsync($"?q={city}&units=metric&APPID={_apiKey}");
            var model = JsonConvert.DeserializeObject<OWMResponse>(forecast);
            return _aggregator.AggregateForcastData(model.ForecastList);
            
        }

    }
}
