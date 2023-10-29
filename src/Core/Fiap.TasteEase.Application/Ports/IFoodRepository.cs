﻿using Fiap.TasteEase.Domain.Aggregates.FoodAggregate;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Models;
using Fiap.TasteEase.Domain.Ports;

namespace Fiap.TasteEase.Application.Ports;

public interface IFoodRepository 
    : IRepository<FoodModel, Food>
{

}