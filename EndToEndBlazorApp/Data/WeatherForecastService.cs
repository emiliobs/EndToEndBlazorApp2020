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
    }
}
