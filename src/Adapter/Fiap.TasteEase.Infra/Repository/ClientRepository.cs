using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.ClientAggregate;
using Fiap.TasteEase.Domain.Aggregates.ClientAggregate.ValueObjects;
using Fiap.TasteEase.Infra.Context;
using Fiap.TasteEase.Infra.Models;

namespace Fiap.TasteEase.Infra.Repository;

public class ClientRepository
    : Repository<ClientModel, Client, ClientId, CreateClientProps, ClientProps, IClientModel>, IClientRepository
{
    public ClientRepository(ApplicationDbContext db) : base(db) { }

}