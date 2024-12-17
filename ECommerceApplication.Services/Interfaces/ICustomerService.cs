namespace ECommerceApplication.Services.Interfaces;

public interface ICustomerService
{
    IEnumerable<object> GetAllCustomerByLoyaltyTier();
    IEnumerable<object> GetCustomerByLoyaltyTierOfYear(int year);
}