using ECommerceApplication.Models;

namespace ECommerceApplication.Services.Interfaces;

public interface ISalesService
{
    Dictionary<string, IEnumerable<ProductSales>> GetProductTotalSalesBySeason(int top);
}
