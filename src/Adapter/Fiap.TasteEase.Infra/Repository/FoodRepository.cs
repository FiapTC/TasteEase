using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using Fiap.TasteEase.Infra.Context;
using Fiap.TasteEase.Infra.Models;

namespace Fiap.TasteEase.Infra.Repository
{
    public class FoodRepository 
        : Repository<FoodModel, Food, FoodId, CreateFoodProps, FoodProps, IFoodModel>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext db) : base(db) { }
    }
}