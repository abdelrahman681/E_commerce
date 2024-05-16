using E_Commerce.Domain.Entity.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Repositry
{
    public interface IBasketItemRepositpry
    {
        Task<CustomerBasket?> GetCustomerBasketAsync(string Id);  
        Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket);  
        Task<bool> DeleteCustomerBasketAsync(string id);  
    }
}
