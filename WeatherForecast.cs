using System;

namespace Swagger.Gateway.Configuration
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF
        {
            get
            {
                return 32 + (int)(TemperatureC / 0.5556);
            }
            set 
            {

            }
        }

        public string Summary { get; set; }
    }
}
