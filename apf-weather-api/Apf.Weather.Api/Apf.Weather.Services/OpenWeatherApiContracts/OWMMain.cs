using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apf.Weather.Services.OpenWeatherApiContracts
{
    public class OWMMain
    {
        [JsonProperty("temp")]
        public Double  Temperature { get; set; }
        [JsonProperty("temp_min")]
        public Double MinTemperature { get; set; }
        [JsonProperty("temp_max")]
        public Double MaxTemperature { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
