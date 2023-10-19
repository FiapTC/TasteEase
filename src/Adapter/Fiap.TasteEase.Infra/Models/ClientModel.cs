using Fiap.TasteEase.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.TasteEase.Infra.Models
{
    [Table("client", Schema = "taste_ease")]
    public class ClientModel : Base
    {
        [Column("name")]
        [MaxLength(512)]
        public string? Name { get; set; }

        [Column("name")]
        [MaxLength(256)]
        public string? TaxpayerNumber { get; set; }
    }
}