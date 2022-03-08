namespace RestWeatherApi
{
    public class WeatherEvent
    {
        public int WeatherEventID { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int ForecastId { get; set; }
        public WeatherForecast Forecast { get; set; }
    }
}
