namespace ECommerceApplication.Services.Interfaces;

public interface ICustomerService
{
    IEnumerable<object> GetCustomerByLoyaltyTierOfYear(int year);
}