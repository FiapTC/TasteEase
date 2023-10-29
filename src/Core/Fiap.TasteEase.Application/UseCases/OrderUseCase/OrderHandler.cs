using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using Mapster;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase;

public class CreateOrderHandler : IRequestHandler<Create, Result<OrderResponseCommand>>
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;
    private readonly IFoodRepository _foodRepository;

    public CreateOrderHandler(IMediator mediator, IOrderRepository orderRepository, IFoodRepository foodRepository)
    {
        _mediator = mediator;
        _orderRepository = orderRepository;
        _foodRepository = foodRepository;
    }

    public async Task<Result<OrderResponseCommand>> Handle(Create request, CancellationToken cancellationToken)
    {
        var orderProps = request.Adapt<CreateOrderProps>();
        var orderResult = Order.Create(orderProps);
        
        if (orderResult.IsFailed)
            return Result.Fail("Erro ao registrar o pedido");

        var order = orderResult.ValueOrDefault;

        if (request.Foods?.Any() ?? false)
        {
            var orderFoods = request.Foods.Adapt<List<OrderFood>>();
            order.AddFood(orderFoods);
        }
        var result = _orderRepository.Add(order);
        await _orderRepository.SaveChanges();

        var foodIds = order.Foods.Select(s => s.FoodId);
        var foodsResult = await _foodRepository.GetByIds(foodIds);
        var totalPrice = order.GetTotalPrice(foodsResult.ValueOrDefault).ValueOrDefault;
        
        if (orderResult.IsFailed)
            return Result.Fail("Erro ao calcular o valor");
        
        return Result.Ok(new OrderResponseCommand(order.Id.Value, order.ClientId, totalPrice, order.Status));
    }
}

public class GetlAllOrderHandler : IRequestHandler<GetAll, Result<IEnumerable<OrderResponseQuery>>>
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;

    public GetlAllOrderHandler(IMediator mediator, IOrderRepository orderRepository)
    {
        _mediator = mediator;
        _orderRepository = orderRepository;
    }

    public async Task<Result<IEnumerable<OrderResponseQuery>>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        var ordersResult = await _orderRepository.GetByFilters(request.Status, request.ClientId);
        
        if (ordersResult.IsFailed)
            return Result.Fail("Erro ao obter os pedidos");

        var orders = ordersResult.ValueOrDefault;
        var response = orders.Adapt<IEnumerable<OrderResponseQuery>>();
        return Result.Ok(response);
    }
}