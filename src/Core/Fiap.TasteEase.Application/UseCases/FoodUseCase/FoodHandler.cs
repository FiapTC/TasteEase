using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.FoodUseCase
{
    public class FoodHandler : IRequestHandler<Create, Result<string>>,
                               IRequestHandler<Update, Result<string>>,
                               IRequestHandler<Delete, Result<string>>
    {
        private readonly IMediator _mediator;
        private readonly IFoodRepository _foodRepository;

        public FoodHandler(IMediator mediator, IFoodRepository foodRepository)
        {
            _mediator = mediator;
            _foodRepository = foodRepository;
        }

        public async Task<Result<string>> Handle(Create request, CancellationToken cancellationToken)
        {
            var foodResult = Food.Create(
                new FoodProps(
                    request.Name,
                    request.Description,
                    request.Price,
                    request.Type));

            if (foodResult.IsFailed)
                return Result.Fail("Erro registrando comida");

            var result = _foodRepository.Add(foodResult.ValueOrDefault);

            await _foodRepository.SaveChanges();

            return Result.Ok("Comida registrada com sucesso");
        }

        public async Task<Result<string>> Handle(Update request, CancellationToken cancellationToken)
        {
            var foodResult = await _foodRepository.GetById(request.Id);
            if(foodResult.IsFailed)
                return Result.Fail("Comida não existe");

            var newFood = foodResult.ValueOrDefault.Update(
                new FoodProps(
                    request.Name, 
                    request.Description, 
                    request.Price, 
                    request.Type));

            if (foodResult.IsFailed)
                return Result.Fail("Erro atualizando comida");

            _foodRepository.Update(newFood.ValueOrDefault);

            await _foodRepository.SaveChanges();

            return Result.Ok("Comida atualizada com sucesso");
        }

        public async Task<Result<string>> Handle(Delete request, CancellationToken cancellationToken)
        {
            var foodResult = await _foodRepository.GetById(request.Id);
            if (foodResult.IsFailed)
                return Result.Fail("Comida não existe");

            _foodRepository.Delete(foodResult.ValueOrDefault);

            await _foodRepository.SaveChanges();

            return Result.Ok("Comida deleteada com sucesso");
        }
    }
}