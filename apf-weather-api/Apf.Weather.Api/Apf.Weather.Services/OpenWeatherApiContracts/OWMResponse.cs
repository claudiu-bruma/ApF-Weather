using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apf.Weather.Services.OpenWeatherApiContracts
{
    public class OWMResponse
    {
        [JsonProperty("list")]
        public List<OWMListItem> ForecastList { get; set; }

    }
}
