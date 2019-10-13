using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Apf.Weather.Services.OpenWeatherApiContracts;
using Apf.Weather.Services.OpenWeatherClient;

namespace Apf.Weather.Services.OpenWeatherDataAggregator
{
    public class OWMAggregator : IOWMAggregator
    {
        public IEnumerable<CityDayForcastDto> AggregateForcastData(List<OWMListItem> forcastList)
        {
            var aggregatedForecast = forcastList
                .Where(x=>x.ForecastDate > DateTime.Now.Date.AddDays(1))
                .GroupBy(f => f.ForecastDate.Date, (forecastDates, forecasts) => new CityDayForcastDto
            {
                Day=( forecastDates.Date  - forcastList.Min(x=>x.ForecastDate.Date)).Days ,
                ForecastDate = forecastDates,
                MaximumTemperature = (Decimal)forecasts.Max(x => x.Temperature.MaxTemperature),
                MinimumTemperature = (Decimal)forecasts.Max(x => x.Temperature.MinTemperature),
                Humidity = (Decimal)forecasts.Average(x => x.Temperature.Humidity),
                Windspeed = (Decimal)forecasts.Average(x => x.Wind.Speed)
            });
            return aggregatedForecast;
        }
    }
}
