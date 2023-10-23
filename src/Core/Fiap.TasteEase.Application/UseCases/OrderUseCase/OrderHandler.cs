using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase
{
    public class OrderHandler : IRequestHandler<Create, Result<string>>
    {
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        public async Task<Result<string>> Handle(Create request, CancellationToken cancellationToken)
        {
            var clientResult = Order.Create(
                new OrderProps(
                    request.Description, 
                    request.Status,
                    "",
                    "",
                    DateTime.UtcNow, 
                    DateTime.UtcNow
                ));
            if (clientResult.IsSuccess)
                return Result.Fail("Erro registrando cliente");

            var result = _orderRepository.Add(clientResult.ValueOrDefault);

            return Result.Ok("Cliente registrado com sucesso");
        }
    }
}