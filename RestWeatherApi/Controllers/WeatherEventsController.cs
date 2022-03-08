#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestWeatherApi;
using RestWeatherApi.Data;

namespace RestWeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherEventsController : ControllerBase
    {
        private readonly RestWeatherApiContext _context;

        public WeatherEventsController(RestWeatherApiContext context)
        {
            _context = context;
        }

        // GET: api/WeatherEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherEvent>>> GetWeatherEvent()
        {
            return await _context.WeatherEvent.Include(e => e.Forecast).ToListAsync();
        }

        // GET: api/WeatherEvents/5
        [HttpGet("{id}")]
        public ActionResult<WeatherEvent> GetWeatherEvent(int id)
        {
            var weatherEvent = _context.WeatherEvent.Include(e => e.Forecast).Where(e => e.WeatherEventID == id);

            if (weatherEvent == null)
            {
                return NotFound();
            }

            return Ok(weatherEvent);
        }

        // PUT: api/WeatherEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherEvent(int id, WeatherEvent weatherEvent)
        {
            if (id != weatherEvent.WeatherEventID)
            {
                return BadRequest();
            }

            _context.Entry(weatherEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherEvent>> PostWeatherEvent(WeatherEvent weatherEvent)
        {
            _context.WeatherEvent.Add(weatherEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherEvent", new { id = weatherEvent.WeatherEventID }, weatherEvent);
        }

        // DELETE: api/WeatherEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherEvent(int id)
        {
            var weatherEvent = await _context.WeatherEvent.FindAsync(id);
            if (weatherEvent == null)
            {
                return NotFound();
            }

            _context.WeatherEvent.Remove(weatherEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherEventExists(int id)
        {
            return _context.WeatherEvent.Any(e => e.WeatherEventID == id);
        }
    }
}
