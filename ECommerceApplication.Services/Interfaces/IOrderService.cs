namespace ECommerceApplication.Services.Interfaces;

public interface IOrderService
{
    IEnumerable<object> GetProductOrderCountOfEachMonthByYear(int year);
    IEnumerable<object> GetProductReturnRateByYear(int year);
}