using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.TasteEase.Infra.Models
{
    [Table("client", Schema = "taste_ease")]
    public class ClientModel  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(512)]
        public string? Name { get; set; }

        [Column("name")]
        [MaxLength(256)]
        public string? TaxpayerNumber { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp without time zone")]
        public DateTime UpdatedAt { get; set; }
    }
}