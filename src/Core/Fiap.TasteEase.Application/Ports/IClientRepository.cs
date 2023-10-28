using Fiap.TasteEase.Domain.Aggregates.ClientAggregate;
using Fiap.TasteEase.Domain.Aggregates.ClientAggregate.ValueObjects;

namespace Fiap.TasteEase.Application.Ports;

public interface IClientRepository 
    : IRepository<IClientModel, Client, ClientId, CreateClientProps, ClientProps, IClientModel>
{

}