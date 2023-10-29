using Fiap.TasteEase.Api.ViewModels;
using Fiap.TasteEase.Api.ViewModels.Order;
using Fiap.TasteEase.Application.UseCases.OrderUseCase;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TasteEase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(
            ILogger<OrderController> logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<ActionResult<ResponseViewModel<CreateOrderResponse>>> Create([FromBody] OrderRequest request)
        {
            try
            {
                var command = request.Adapt<Create>();
                var response = await _mediator.Send(command);

                if (response.IsFailed)
                {
                    return StatusCode((int)StatusCodes.Status400BadRequest, 
                        new ResponseViewModel<CreateOrderResponse>
                        {
                            Error = true,
                            ErrorMessages = response.Errors.Select(x => x.Message),
                            Data = null!
                        }
                    );
                }

                return StatusCode((int)StatusCodes.Status201Created, 
                    new ResponseViewModel<CreateOrderResponse>
                    {
                        Data = response.ValueOrDefault.Adapt<CreateOrderResponse>()
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, 
                    new ResponseViewModel<CreateOrderResponse>
                    {
                        Error = true,
                        ErrorMessages = new List<string> { ex.Message },
                        Data = null!
                    }
                );
            }
        }
        
        [HttpGet()]
        public async Task<ActionResult<ResponseViewModel<IEnumerable<OrderResponse>>>> GetAll([FromQuery] int? status, Guid? clientId)
        {
            try
            {
                var response = await _mediator.Send(new GetAll { ClientId = clientId, Status = (OrderStatus?)status});

                if (response.IsFailed)
                {
                    return StatusCode((int)StatusCodes.Status400BadRequest, 
                        new ResponseViewModel<IEnumerable<OrderResponse>>
                        {
                            Error = true,
                            ErrorMessages = response.Errors.Select(x => x.Message),
                            Data = null!
                        }
                    );
                }

                return StatusCode((int)StatusCodes.Status200OK, 
                    new ResponseViewModel<IEnumerable<OrderResponse>>
                    {
                        Data = response.ValueOrDefault.Adapt<IEnumerable<OrderResponse>>()
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, 
                    new ResponseViewModel<IEnumerable<OrderResponse>>
                    {
                        Error = true,
                        ErrorMessages = new List<string> { ex.Message },
                        Data = null!
                    }
                );
            }
        }
        
        
        [HttpGet("/[controller]/{orderId}")]
        public async Task<ActionResult<ResponseViewModel<OrderResponse>>> GetById([FromRoute] Guid orderId)
        {
            try
            {
                var response = await _mediator.Send(new GetById { OrderId = orderId });

                if (response.IsFailed)
                {
                    return StatusCode((int)StatusCodes.Status400BadRequest, 
                        new ResponseViewModel<OrderResponse>
                        {
                            Error = true,
                            ErrorMessages = response.Errors.Select(x => x.Message),
                            Data = null!
                        }
                    );
                }

                return StatusCode((int)StatusCodes.Status200OK, 
                    new ResponseViewModel<OrderResponse>
                    {
                        Data = response.ValueOrDefault.Adapt<OrderResponse>()
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, 
                    new ResponseViewModel<OrderResponse>
                    {
                        Error = true,
                        ErrorMessages = new List<string> { ex.Message },
                        Data = null!
                    }
                );
            }
        }
        
        [HttpPost("/[controller]/{orderId}/status")]
        public async Task<ActionResult<ResponseViewModel<CreateOrderResponse>>> UpdateStatus([FromBody] UpdateOrderStatusRequest request, [FromRoute] Guid orderId)
        {
            try
            {
                var response = await _mediator.Send(new UpdateStatus { OrderId = orderId, Status = request.Status});

                if (response.IsFailed)
                {
                    return StatusCode((int)StatusCodes.Status400BadRequest, 
                        new ResponseViewModel<CreateOrderResponse>
                        {
                            Error = true,
                            ErrorMessages = response.Errors.Select(x => x.Message),
                            Data = null!
                        }
                    );
                }

                return StatusCode((int)StatusCodes.Status200OK, 
                    new ResponseViewModel<CreateOrderResponse>
                    {
                        Data = response.ValueOrDefault.Adapt<CreateOrderResponse>()
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, 
                    new ResponseViewModel<CreateOrderResponse>
                    {
                        Error = true,
                        ErrorMessages = new List<string> { ex.Message },
                        Data = null!
                    }
                );
            }
        }
    }
}