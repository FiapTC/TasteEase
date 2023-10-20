using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TasteEase.Api.Controllers
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
        private readonly IOrderRepository _orderRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IOrderRepository orderRepository
        )
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Order>> Get()
        {
            var teste = await _orderRepository.GetAll();
            return teste.ValueOrDefault;
        }
    }
}