using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apf.Weather.Services.OpenWeatherApiContracts
{
    public class OWMListItem
    {
        [JsonProperty("dt_txt")]
        public DateTime ForecastDate { get; set; }
        [JsonProperty("main")]
        public OWMMain  Temperature { get; set; }
        [JsonProperty("wind")]
        public OWMWind Wind { get; set; }

    }
}
