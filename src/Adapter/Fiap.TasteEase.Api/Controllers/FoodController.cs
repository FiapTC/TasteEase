﻿using Fiap.TasteEase.Api.ViewModels;
using Fiap.TasteEase.Api.ViewModels.Food;
using Fiap.TasteEase.Application.UseCases.FoodUseCase;
using Mapster;
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
        public async Task<ActionResult<ResponseViewModel<string>>> Post(CreateFoodRequest request)
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

        [HttpPut]
        public async Task<ActionResult<ResponseViewModel<string>>> Put(UpdateFoodRequest request)
        {
            try
            {
                var command = request.Adapt<Update>();

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
        public async Task<ActionResult<ResponseViewModel<string>>> Delete(DeleteFoodRequest request)
        {
            try
            {
                var command = request.Adapt<Delete>();

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
