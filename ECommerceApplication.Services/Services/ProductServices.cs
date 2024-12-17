using System.Text.Json;
using ECommerceApplication.Models;
using ECommerceApplication.Services.Interfaces;

namespace ECommerceApplication.Services.Services;
public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Partner>> GetProductsPartner(int limit)
    {
        try
        {
            string uri = $"https://fakestoreapi.com/products?limit={limit}";

            var response = await _httpClient.GetAsync($"?limit={limit}");

            response.EnsureSuccessStatusCode();

            var responseResult = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonSerializer.Deserialize<IEnumerable<Partner>>(responseResult);

            return jsonObject;
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<Partner>();
        }
    }
}
