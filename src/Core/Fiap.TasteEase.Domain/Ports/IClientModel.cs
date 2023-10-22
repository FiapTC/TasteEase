using Fiap.TasteEase.Domain.Ports;

public interface IClientModel : IModel
{
    public string Name { get; set; }
    public string TaxpayerNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}