using Fiap.TasteEase.Application.Ports;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.FoodUseCase
{
    public class FoodHandler : IRequestHandler<Create, Result<string>>
    {
        private readonly IMediator _mediator;
        private readonly IFoodRepository _foodRepository;

        public FoodHandler(IMediator mediator, IFoodRepository foodRepository)
        {
            _mediator = mediator;
            _mediator = mediator;
            _foodRepository = foodRepository;
        }

        public Task<Result<string>> Handle(Create request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}