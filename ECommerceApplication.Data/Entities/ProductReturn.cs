namespace ECommerceApplication.Data.Entities;

public record ProductReturn
{
    public string ProductId { get; set; }
    public int UnitsReturned { get; set; }
    public DateTime ReturnDate { get; set; }

    public ProductReturn(string productId, int unitsReturned, DateTime returnDate)
    {
        ProductId = productId;
        UnitsReturned = unitsReturned;
        ReturnDate = returnDate;
    }
}
