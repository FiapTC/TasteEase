using Fiap.TasteEase.Domain.Aggregates.Common;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using FluentResults;

namespace Fiap.TasteEase.Domain.Aggregates.FoodAggregate
{
    public class Food : Entity<FoodId, FoodProps>, IFoodAggregate
    {
        public Food(FoodProps props, FoodId? id = default) : base(props, id) { }

        public string? Name => Props.Name;
        public string? Description => Props.Description;
        public double Price => Props.Price;
        public FoodType Type => Props.Type;
        public DateTime CreatedAt => Props.CreatedAt;
        public DateTime UpdatedAt => Props.UpdatedAt;

        public static Result<Food> Create(CreateFoodProps props)
        {
            var date = DateTime.UtcNow;
            var foodProps = new FoodProps(
                props.Name,
                props.Description,
                props.Price,
                props.Type,
                date,
                date
            );
            
            var food = new Food(foodProps);
            return Result.Ok(food);
        }

        public static Result<Food> Rehydrate(FoodProps props, FoodId id)
            => Result.Ok(new Food(props, id));

        public static Result<Food> Rehydrate(IFoodModel model)
        {
            var food = new Food(
                new FoodProps(
                    model.Name,
                    model.Description,
                    model.Price,
                    model.Type,
                    model.CreatedAt,
                    model.UpdatedAt
                ),
                new FoodId(model.Id)
            );

            return Result.Ok(food);
        }
    }
}

public record FoodProps(
    string Name,
    string Description,
    double Price,
    FoodType Type,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CreateFoodProps(
    string Name,
    string Description,
    double Price,
    FoodType Type
);