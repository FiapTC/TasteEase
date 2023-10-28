using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using Mapster;
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
            var orderProps = request.Adapt<CreateOrderProps>();
            var orderResult = Order.Create(orderProps);
            
            if (orderResult.IsFailed)
                return Result.Fail("Erro registrando cliente");

            var order = orderResult.ValueOrDefault;

            if (request.Foods?.Any() ?? false)
            {
                var orderFoods = new List<OrderFood>(request.Foods.Count());
                orderFoods.AddRange(request.Foods
                    .Select(food => 
                        new OrderFood(new OrderFoodProps(order.Id!.Value, food.FoodId, food.Quantity)
                        )
                    )
                );
                order.AddFood(orderFoods);
            }
            var result = _orderRepository.Add(order);

            return Result.Ok("Cliente registrado com sucesso");
        }
    }
}