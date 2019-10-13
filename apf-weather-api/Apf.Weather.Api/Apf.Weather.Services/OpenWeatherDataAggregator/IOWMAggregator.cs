using Apf.Weather.Services.OpenWeatherApiContracts;
using Apf.Weather.Services.OpenWeatherClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apf.Weather.Services.OpenWeatherDataAggregator
{
    public interface IOWMAggregator
    {
        IEnumerable<CityDayForcastDto> AggregateForcastData(List<OWMListItem> forcastList);
    }
}
