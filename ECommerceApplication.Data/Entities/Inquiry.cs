namespace ECommerceApplication.Data.Entities;

public record Inquiry
{
    public required string CategoryName { get; set; }
    public int Quantity { get; set; }
    public DateTime InquiryDate { get; set; }
}
