using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.FoodAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.TasteEase.Infra.Models
{
    [Table("food", Schema = "taste_ease")]
    public class FoodModel : Model, IFoodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [MaxLength(512)]
        public string? Name { get; set; }

        [Column("description")]
        [MaxLength(512)]
        public string? Description { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("type")]
        public FoodType Type { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime UpdatedAt { get; set; }
        
        public virtual ICollection<OrderFoodModel>? Orders { get; set; } = null!;
    }
}