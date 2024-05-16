using AutoMapper;
using AutoMapper.Execution;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity;

namespace E_commerce.API.Helper
{
    public class PictureURLResolver : IValueResolver<Products, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PictureURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Products source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrWhiteSpace(source.PictureUrl)? $"{_configuration["BaseUrl"]}{source.PictureUrl}":string.Empty; 
        }
    }
}
