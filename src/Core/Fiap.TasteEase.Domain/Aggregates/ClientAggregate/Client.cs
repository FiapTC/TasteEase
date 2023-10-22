using Fiap.TasteEase.Domain.Aggregates.ClientAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Aggregates.Common;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.ClientAggregate
{
    public class Client : Entity<ClientId, ClientProps>, IClientAggregate
    {
        public Client(ClientProps props, ClientId? id = default) : base(props, id) { }

        public string Name => Props.Name;
        public string TaxpayerNumber => Props.Name;
        public DateTime CreatedAt => Props.CreatedAt;
        public DateTime UpdatedAt => Props.UpdatedAt;

        public static Result<Client> Create(ClientProps props)
        {
            var date = DateTime.UtcNow;
            var order = new Client(
                props with
                {
                    CreatedAt = date,
                    UpdatedAt = date
                }
            );
            return Result.Ok(order);
        }

        public static Result<Client> Rehydrate(ClientProps props, ClientId id)
        => Result.Ok(new Client(props, id));

        public static Result<Client> Rehydrate(IClientModel model)
        {
            var order = new Client(
                new ClientProps(
                    model.Name,
                    model.TaxpayerNumber,
                    model.CreatedAt,
                    model.UpdatedAt
                ),
                new ClientId(model.Id)
            );

            return Result.Ok(order);
        }
    }
}

public record ClientProps(
    string Name,
    string TaxpayerNumber,
    DateTime CreatedAt,
    DateTime UpdatedAt
);