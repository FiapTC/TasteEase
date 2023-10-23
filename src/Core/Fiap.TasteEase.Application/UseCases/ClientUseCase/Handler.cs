using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.ClientAggregate;
using FluentResults;
using MediatR;

namespace Fiap.TasteEase.Application.UseCases.ClientUseCase
{
    public class Handler : IRequestHandler<Create, Result<string>>
    {
        private readonly IMediator _mediator;
        private readonly IClientRepository _clientRepository;

        public Handler(IMediator mediator, IClientRepository clientRepository)
        {
            _mediator = mediator;
            _clientRepository = clientRepository;
        }

        public async Task<Result<string>> Handle(Create request, CancellationToken cancellationToken)
        {
            var clientResult = Client.Create(new ClientProps(request.Name, request.TaxpayerNumber, DateTime.Now, DateTime.Now));
            if (clientResult.IsSuccess)
                return Result.Fail("Erro registrando cliente");

            var result = _clientRepository.Add(clientResult.ValueOrDefault);
            await _clientRepository.SaveChanges();

            return Result.Ok("Cliente registrado com sucesso");
        }
    }
}