using System.Collections.Generic;

namespace RestaurantAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int numberResults, int minTemperature, int maxTemperature);
    }
}