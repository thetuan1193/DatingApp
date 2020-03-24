using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
private readonly DataContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _context= context;
            _logger = logger;
        }
[HttpGet]
public async Task<IActionResult> GetWeather()
{
    var result = await _context.weatherforecasts.ToListAsync();
    return Ok(result);
}
[HttpGet("{id}")]
public async Task<IActionResult> GetWeather(int id)
{
    var result = await _context.weatherforecasts.FirstOrDefaultAsync(x=> x.id == id);
    return Ok(result);
}
        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }    
    }
}
