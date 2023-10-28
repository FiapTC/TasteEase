using Fiap.TasteEase.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TasteEase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {

        private readonly ILogger<FoodController> _logger;
        private readonly IMediator _mediator;

        public FoodController(
            ILogger<FoodController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<string>>> Post()
        {
            try
            {
                var command = new Application.UseCases.FoodUseCase.Create()
                {
                    Name = "Test",
                    Description = "Dessert",
                    Price = 1,
                    Type = Domain.Aggregates.FoodAggregate.ValueObjects.FoodType.Dessert
                };

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

        [HttpPut]
        public async Task<ActionResult<ResponseViewModel<string>>> Put()
        {
            try
            {
                var command = new Application.UseCases.FoodUseCase.Update()
                {
                    Id = Guid.Parse("55d9a591-e4fa-4f98-aa52-4543f3c61c41"),
                    Name = "Test Update",
                    Description = "Dessert Update",
                    Price = 2,
                    Type = Domain.Aggregates.FoodAggregate.ValueObjects.FoodType.Dessert
                };

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

        [HttpDelete]
        public async Task<ActionResult<ResponseViewModel<string>>> Delete()
        {
            try
            {
                var command = new Application.UseCases.FoodUseCase.Delete()
                {
                    Id = Guid.Parse("55d9a591-e4fa-4f98-aa52-4543f3c61c41"),
                };

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

    }
}
