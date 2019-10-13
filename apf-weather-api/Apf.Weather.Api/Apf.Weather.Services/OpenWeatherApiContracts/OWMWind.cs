using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apf.Weather.Services.OpenWeatherApiContracts
{
    public class OWMWind
    {
        [JsonProperty("speed")]
        public Double Speed { get; set; }
    }
}
