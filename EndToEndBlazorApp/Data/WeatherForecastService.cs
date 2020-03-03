using EndToEndBlazorApp.Data.EndToEnd;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndToEndBlazorApp.Data
{
    public class WeatherForecastService
    {
        private readonly EndtoEndContext _context;

        public WeatherForecastService(EndtoEndContext context)
        {
            this._context = context;
        }

        public async Task<List<WeatherForecast>> GetForecastAsync(string currentuser)
        {
            //Get water forescats:
            return await _context.WeatherForecast.Where(wf => wf.UserName == currentuser).AsNoTracking().ToListAsync();
        }

        public  Task<WeatherForecast> CreateForecastAsync(WeatherForecast weatherForecast)
        {
             _context.WeatherForecast.Add(weatherForecast);
             _context.SaveChanges();
            return   Task.FromResult(weatherForecast);
        }

        public Task<bool> UpdateForecastAsync(WeatherForecast weatherForecast)
        {
            var existingWeatherForecast = _context.WeatherForecast.FirstOrDefault(x => x.Id == weatherForecast.Id);
            if (existingWeatherForecast !=null)
            {
                existingWeatherForecast.Date = weatherForecast.Date;
                existingWeatherForecast.Summary = weatherForecast.Summary;
                existingWeatherForecast.TemperatureC = weatherForecast.TemperatureC;
                existingWeatherForecast.TemperatureF = weatherForecast.TemperatureF;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteForecastAsync(WeatherForecast weatherForecast)
        {
            var existingWeatherForecast =  _context.WeatherForecast.FirstOrDefault(x => x.Id == weatherForecast.Id);
            if (existingWeatherForecast != null)
            {
                _context.WeatherForecast.Remove(existingWeatherForecast);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
