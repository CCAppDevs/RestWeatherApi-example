#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestWeatherApi;

namespace RestWeatherApi.Data
{
    public class RestWeatherApiContext : DbContext
    {
        public RestWeatherApiContext (DbContextOptions<RestWeatherApiContext> options)
            : base(options)
        {
        }

        public DbSet<RestWeatherApi.WeatherEvent> WeatherEvent { get; set; }
        public DbSet<RestWeatherApi.WeatherForecast> WeatherForecast { get; set; }
    }
}
