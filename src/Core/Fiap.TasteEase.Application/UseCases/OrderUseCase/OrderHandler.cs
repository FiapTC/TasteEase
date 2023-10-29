using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using FluentResults;
using Mapster;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.OrderUseCase;

public class CreateOrderHandler : IRequestHandler<Create, Result<string>>
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IMediator mediator, IOrderRepository orderRepository)
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
            var orderFoods = request.Foods.Adapt<List<OrderFood>>();
            order.AddFood(orderFoods);
        }
        var result = _orderRepository.Add(order);
        await _orderRepository.SaveChanges();

        return Result.Ok("Cliente registrado com sucesso");
    }
}

public class GetlAllOrderHandler : IRequestHandler<GetAll, Result<IEnumerable<OrderResponseDto>>>
{
    private readonly IMediator _mediator;
    private readonly IOrderRepository _orderRepository;

    public GetlAllOrderHandler(IMediator mediator, IOrderRepository orderRepository)
    {
        _mediator = mediator;
        _orderRepository = orderRepository;
    }

    public async Task<Result<IEnumerable<OrderResponseDto>>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        var ordersResult = await _orderRepository.GetAll();
        
        if (ordersResult.IsFailed)
            return Result.Fail("Erro ao obter os pedidos");

        var orders = ordersResult.ValueOrDefault;
        var response = orders.Adapt<IEnumerable<OrderResponseDto>>();
        return Result.Ok(response);
    }
}