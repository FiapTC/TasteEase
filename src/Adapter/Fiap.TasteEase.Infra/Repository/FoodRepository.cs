using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Models;
using Fiap.TasteEase.Infra.Context;

namespace Fiap.TasteEase.Infra.Repository
{
    public class FoodRepository 
        : Repository<FoodModel, Food, FoodId, CreateFoodProps, FoodProps>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext db) : base(db) { }
    }
}