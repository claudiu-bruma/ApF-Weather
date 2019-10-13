using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apf.Weather.Services.OpenWeatherClient
{
    public class CityDayForcastDto
    {    
        public int Day { get; set; }      
        public DateTime ForecastDate { get; set; }        
        public Decimal MinimumTemperature { get; set; }       
        public Decimal MaximumTemperature { get; set; }         
        public Decimal Humidity { get; set; }       
        public Decimal Windspeed { get; set; }
    }
}
