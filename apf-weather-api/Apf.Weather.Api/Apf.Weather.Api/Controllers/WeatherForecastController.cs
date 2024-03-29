﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Apf.Weather.Services.OpenWeatherClient;
using Apf.Weather.Services.OpenWeatherDataAggregator;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Apf.Weather.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOpenWeatherClient _openWeatherClient;
        private IMemoryCache _cache;
        private const string country = "DE";
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOpenWeatherClient openWeatherClient, IMemoryCache cache)
        {
            _logger = logger;
            _openWeatherClient = openWeatherClient;
            _cache = cache;

        }
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDayForcastDto>>> Get(string location)
        {
            if (String.IsNullOrEmpty(location))
            {
                return new NotFoundResult();
            }
            try
            {
                var items = await
                         _cache.GetOrCreateAsync(location, entry =>
                     {
                         entry.SlidingExpiration = TimeSpan.FromHours(3);
                         return _openWeatherClient.Get5DayForecast($"{location},{country}");
                     });

                return new OkObjectResult(items);
            }
            catch (HttpRequestException)
            {
                //location not found
                return new NotFoundResult();
            }
        }
    }
}
