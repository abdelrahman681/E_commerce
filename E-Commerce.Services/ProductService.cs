using AutoMapper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Domain.Specification;
using E_Commerce.Repositry.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unit,IMapper mapper)
        {
           _unit = unit;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync()
        {
            var brand= await _unit.Reposity<ProductBrand,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandTypeDto>>(brand);
        }

        public async Task<ProductPagination<ProductToReturnDTO>> GetAllProductsAsync(ProductSpesificationParamter Specparamter)
        {
            var spec = new ProudectSpecification(Specparamter);
            var Products = await _unit.Reposity<Products, int>().GetAllwithspecififcationAsync(spec);
            var countspec = new ProductCountWithSpec(Specparamter);
            var count = await _unit.Reposity<Products, int>().GetProductCountwithspecififcationAsync(countspec);
            var MappedProduct= _mapper.Map<IReadOnlyList<ProductToReturnDTO>>(Products);
            return new ProductPagination<ProductToReturnDTO> 
            {
                Data = MappedProduct,
                PageSize = Specparamter.PageSize,
                PageIndex =Specparamter.IndexPage,
                TotalCount=count
            };
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync()
        {
            var type = await _unit.Reposity<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandTypeDto>>(type);
        }

        public async Task<ProductToReturnDTO> GetProductByIdAsync(int id)
        {
            var spec = new ProudectSpecification(id);
            var productid=await _unit.Reposity<Products,int>().GetByIdwithspecificationAsync(spec);
            return _mapper.Map<ProductToReturnDTO>(productid);
        }
    }
}
