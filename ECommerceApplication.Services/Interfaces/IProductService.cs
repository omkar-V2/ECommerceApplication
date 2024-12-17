using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Models;

namespace ECommerceApplication.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Partner>> GetProductsPartner(int limit);
    }
}
