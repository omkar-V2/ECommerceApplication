using ECommerceApplication.Data;
using ECommerceApplication.Services.Interfaces;

namespace ECommerceApplication.Services.Services;
public class CustomerService : ICustomerService
{

    public IEnumerable<object> GetCustomerByLoyaltyTierOfYear(int year)
    {
        var result = Db.CustomerActivities
                     .Where(yr => yr.PurchaseDate.Year == year)
                     .GroupBy(groupCust => new
                     {
                         groupCust.PurchaseDate.Year,
                         groupCust.CustomerId
                     })
                     .Select(cust => new
                     {
                         customerId = cust.Key.CustomerId,
                         loyaltyTier = GetLoyaltyTier(cust.Count())
                     });


        return result;
    }

    private string GetLoyaltyTier(int customerActivityCount)
    {
        if (customerActivityCount >= 12)
            return "Platinum"; //-Platinum(12 or more purchases per year)
        else if (customerActivityCount >= 6)//&& customerActivityCount <= 11
            return "Gold";// -Gold(6 to 11 purchases per year)
        else if (customerActivityCount >= 1)//&& customerActivityCount <= 5
            return "Silver"; // -Silver(1 to 5 purchases per year).
        else
            return "None";
    }

}
