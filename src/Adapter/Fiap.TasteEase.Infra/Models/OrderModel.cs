using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;

namespace Fiap.TasteEase.Infra.Models;

[Table("order", Schema = "taste_ease")]
public class OrderModel : Model
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("description")]
    [MaxLength(512)]
    public string? Description { get; set; }

    [Column("status")]
    [MaxLength(128)]
    public OrderStatus Status { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    [Required]
    [MaxLength(512)]
    public string CreatedBy { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("updated_by")]
    [Required]
    [MaxLength(512)]
    public string UpdatedBy { get; set; }
}
