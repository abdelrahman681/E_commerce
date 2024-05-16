using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductPagination<ProductToReturnDTO>> GetAllProductsAsync(ProductSpesificationParamter Specparamter);

        Task<ProductToReturnDTO> GetProductByIdAsync(int id);

        Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync();

        Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync();
    }
}
