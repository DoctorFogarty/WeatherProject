using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherWeb.Models
{
    public class CityWeatherData
    {
        public string City { get; set; }
        public string State { get; set; }
        public string WeatherType { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int DewPoint { get; set; }
        public double Pressure { get; set; }
        public int WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string IMG_URL { get; set; }
    }
}