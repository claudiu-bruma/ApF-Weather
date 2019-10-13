using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apf.Weather.Services.OpenWeatherClient
{
    public interface IOpenWeatherClient
    {
          Task<IEnumerable<CityDayForcastDto>> Get5DayForecast(string city);
    }
}
