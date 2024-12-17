using ECommerceApplication.Data;
using ECommerceApplication.Models;
using ECommerceApplication.Services.Interfaces;

namespace ECommerceApplication.Services.Services;
public class SalesService : ISalesService
{

    public Dictionary<string, IEnumerable<ProductSales>> GetProductTotalSalesBySeason(int top)
    {
        var result = Db.MonthlySales
                   .GroupBy(groupSales => GetSeason(groupSales.SaleDate.Month))
                   .ToDictionary(getMonth => getMonth.Key,
                   getProduct => getProduct.GroupBy(prdgroup => prdgroup.ProductName)
                                            .Select(prod => new
                                            ProductSales
                                            {
                                                product = prod.Key,
                                                sales = prod.Sum(prdsale => prdsale.QuantitySold)
                                            })
                                            .OrderByDescending(vol => vol.sales)
                                            .Take(top));

        return result;
    }

    private string GetSeason(int monthNum)
    {
        return monthNum switch
        {
            12 or 1 or 2 => "Winter",
            9 or 10 or 11 => "Autumn",
            6 or 7 or 8 => "Summer",
            3 or 4 or 5 => "Spring",
            _ => "None",
        };
    }
}
