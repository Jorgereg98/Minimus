using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.Models;

namespace Minimus.Services.Proxy
{
    interface IProxyWeather
    {
        WeatherObject weather(string city);
        ForecastObject forecast(string city);
    }
}
