using Fiap.TasteEase.Application.Ports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.TasteEase.Infra.Models;

[Table("client", Schema = "taste_ease")]
public class ClientModel : Model, IClientModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [MaxLength(512)]
    public string? Name { get; set; }

    [Column("taxpayer_number")]
    [MaxLength(256)]
    public string? TaxpayerNumber { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }
    
    public virtual ICollection<OrderModel>? Order { get; set; } = null!;
}