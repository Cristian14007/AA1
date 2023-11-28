using Microsoft.AspNetCore.Mvc;

using AA1.Data;
using AA1.Business;

namespace AA1.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("AA1account")]
        public IActionResult GetAA1Account()
        {
            var accountNumber = "1";
            var AA1AccountRepository = new AA1AccountRepository();
            var AA1AccountService = new AA1AccountService(AA1AccountRepository);
            AA1AccountService.MakeDeposit(accountNumber, 1000,"Propina");
            AA1AccountService.MakeWithdrawal(accountNumber, 500, "Pago");
            string history = AA1AccountService.GetAccountHistory(accountNumber); 
            return Ok(history);
        }
}
