﻿using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Infra.Models;
using Mapster;

namespace Fiap.TasteEase.Infra.Mappers
{
    internal class OrderMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Order, OrderModel>()
                .Map(model => model.Id, src => src.Id!.Value)
                .Map(model => model.Description, src => src.Description)
                .Map(model => model.Status, src => src.Status)
                .Map(model => model.CreatedAt, src => src.CreatedAt)
                .Map(model => model.CreatedBy, src => src.CreatedBy)
                .Map(model => model.UpdatedAt, src => src.UpdatedAt)
                .Map(model => model.UpdatedBy, src => src.UpdatedBy);
            
            config.ForType<OrderFood, OrderFoodModel>()
                .Map(model => model.Id, src => src.Id!.Value)
                .Map(model => model.OrderId, src => src.OrderId)
                .Map(model => model.FoodId, src => src.FoodId)
                .Map(model => model.Quantity, src => src.Quantity)
                .Map(model => model.CreatedAt, src => src.CreatedAt);
        }
    }
}
