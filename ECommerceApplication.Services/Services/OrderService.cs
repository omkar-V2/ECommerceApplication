using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Data;
using ECommerceApplication.Data.Entities;
using ECommerceApplication.Services.Interfaces;

namespace ECommerceApplication.Services.Services;
public class OrderService : IOrderService
{
    public IEnumerable<object> GetProductOrderCountOfEachMonthByYear(int year)
    {
        var result = Db.Orders
                     .Where(yr => yr.PurchaseTime.Year == year)
                     .SelectMany(ord => ord.Products, (ord, product) => new
                     {
                         productId = product.ProductId,
                         productName = product.ProductName,
                         productPurchaseTime = ord.PurchaseTime
                     })
                     .GroupBy(groupmonth => new { groupmonth.productId, groupmonth.productName })
                     .Select(prod => new
                     {
                         productId = prod.Key.productId,
                         productName = prod.Key.productName,
                         monthlyOrders = prod
                                         .GroupBy(grpMonth => grpMonth.productPurchaseTime.ToString("MMM"))
                                         .ToDictionary(mon => mon.Key, monthCount => monthCount.Count())
                     });

        return result;
    }

    public IEnumerable<object> GetProductReturnRateByYear(int year)
    {
        var result = Db.Orders
                     .Where(yr => yr.PurchaseTime.Year == year)
                     .SelectMany(ord => ord.Products, (ord, product) => new
                     {
                         productId = product.ProductId,
                         productName = product.ProductName,
                         productSoldUnit = 1
                     })
                    .GroupBy(groupProd => new { groupProd.productId, groupProd.productName })
                    .Select(prod => new
                    {
                        prod.Key.productId,
                        prod.Key.productName,
                        totalSoldUnit = prod.Sum(sldunit => sldunit.productSoldUnit)
                    })
                    .Join(Db.Returns, ret => ret.productId, ord => ord.ProductId, (soldProd, returnProd) => new
                    {
                        soldProd.productId,
                        soldProd.productName,
                        soldProd.totalSoldUnit,
                        returnProd.UnitsReturned,
                        returnRate = (returnProd.UnitsReturned / soldProd.totalSoldUnit)
                    });


        return result;
    }
}

