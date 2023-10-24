using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.ClientUseCase
{
    public class Create : IRequest<Result<string>>
    {
        public string Name { get; set; }
        public string TaxpayerNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedA { get; set; }
    }

    public class Delete : IRequest<string> 
    {
    }
}