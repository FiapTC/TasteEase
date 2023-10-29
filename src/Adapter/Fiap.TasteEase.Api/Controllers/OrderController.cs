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
        public async Task<ActionResult<ResponseViewModel<string>>> Create([FromBody] OrderRequest request)
        {
            try
            {
                var command = request.Adapt<Create>();
                var response = await _mediator.Send(command);

                if (response.IsFailed)
                {
                    return StatusCode((int)StatusCodes.Status400BadRequest, 
                        new ResponseViewModel<string>
                        {
                            Error = true,
                            ErrorMessages = response.Errors.Select(x => x.Message),
                            Data = null!
                        }
                    );
                }

                return StatusCode((int)StatusCodes.Status201Created, 
                    new ResponseViewModel<string>
                    {
                        Data = response.ValueOrDefault
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, 
                    new ResponseViewModel<string>
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
    }
}