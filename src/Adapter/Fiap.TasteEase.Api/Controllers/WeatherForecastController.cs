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
            var teste2 = await _orderRepository.GetById(Guid.Parse("968d2d5d-8955-4c23-b51c-4161b5aefc89"));
            var teste3 = await _orderRepository.Get(w => w.Id == Guid.Parse("968d2d5d-8955-4c23-b51c-4161b5aefc89"));
            return teste.ValueOrDefault;
        }
    }
}