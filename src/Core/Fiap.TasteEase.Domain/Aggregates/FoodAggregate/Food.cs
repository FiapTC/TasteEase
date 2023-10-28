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
        public DateTime? CreatedAt => Props.CreatedAt;
        public DateTime? UpdatedAt => Props.UpdatedAt;

        public static Result<Food> Create(FoodProps props)
        {
            var date = DateTime.UtcNow;
            var Food = new Food(
                props with
                {
                    CreatedAt = date,
                    UpdatedAt = date
                }
            );
            return Result.Ok(Food);
        }

        public static Result<Food> Rehydrate(FoodProps props, FoodId id)
            => Result.Ok(new Food(props, id));

        public static Result<Food> Rehydrate(IFoodModel model)
        {
            var Food = new Food(
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

            return Result.Ok(Food);
        }

        public Result<Food> Update(FoodProps props)
        {
            Props = Props with
            {
                Name = props.Name,
                Description = props.Description,
                Type = props.Type,
                Price = props.Price,
                UpdatedAt = DateTime.UtcNow
            };

            return Result.Ok(this);
        }
    }
}

public record FoodProps(
    string Name,
    string Description,
    double Price,
    FoodType Type,
    DateTime? CreatedAt = null,
    DateTime? UpdatedAt = null
);