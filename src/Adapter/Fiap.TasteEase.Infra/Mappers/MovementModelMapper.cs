using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Infra.Models;
using Mapster;

namespace Fiap.TasteEase.Infra.Mappers
{
    internal class MovementModelMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Order, OrderModel>()
                .Map(model => model.Id, movement => movement.Id!.Value)
                .Map(model => model.Description, movement => movement.Description)
                .Map(model => model.Status, movement => movement.Status)
                .Map(model => model.CreatedAt, movement => movement.CreatedAt)
                .Map(model => model.CreatedBy, movement => movement.CreatedBy)
                .Map(model => model.UpdatedAt, movement => movement.UpdatedAt)
                .Map(model => model.UpdatedBy, movement => movement.UpdatedBy);
        }
    }
}
