using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.ClientAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Infra.Models;
using Mapster;
using MediatR;
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
        private readonly IMediator _mediator;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IOrderRepository orderRepository,
            IMediator mediator
        )
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                var command = new Application.UseCases.ClientUseCase.Create()
                {
                    Name = "Test",
                    TaxpayerNumber = "123456789",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedA = DateTime.UtcNow
                };

                var response = await _mediator.Send(command);

                return new List<Order>();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            //var newOrder = Order.Create(
            //    new OrderProps("teste2", OrderStatus.Delivered, DateTime.UtcNow, "1", DateTime.UtcNow, "2"));
            //_orderRepository.Add(newOrder.ValueOrDefault);

            //var teste3 = await _orderRepository.Get(w => w.Id == Guid.Parse("968d2d5d-8955-4c23-b51c-4161b5aefc89"));
            //var teste2 = await _orderRepository.GetById(Guid.Parse("968d2d5d-8955-4c23-b51c-4161b5aefc89"));

            //var aggregate = teste2.ValueOrDefault;
            //aggregate.UpdateStatus(OrderStatus.Preparing);
            //_orderRepository.Update(aggregate);

            //await _orderRepository.SaveChanges();
            //var teste = await _orderRepository.GetAll();
            //return teste.ValueOrDefault;
        }

        //[HttpGet(Name = "TestClient")]
        //public async Task<string> TestClient()
        //{
        //    var command = new Application.UseCases.ClientUseCase.Create()
        //    {
        //        Name = "Test",
        //        TaxpayerNumber = "123456789",
        //        CreatedAt = DateTime.UtcNow,
        //        UpdatedA = DateTime.UtcNow
        //    };

        //    var response = await _mediator.Send(command);

        //    return response;
        //}
    }
}