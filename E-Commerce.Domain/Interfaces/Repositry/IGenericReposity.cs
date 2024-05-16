using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Repositry
{
    public interface IGenericReposity <TEntity,TKey> where TEntity :BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllwithspecififcationAsync(ISpecification<TEntity> specification);
        Task<int> GetProductCountwithspecififcationAsync(ISpecification<TEntity> specification);
        Task<TEntity > GetByIdAsync(TKey Id);
        Task<TEntity > GetByIdwithspecificationAsync(ISpecification<TEntity> specification);
        Task AddAsync(TEntity  entity);
        void Delete(TEntity?  entity);
        void Update(TEntity?  entity);
    }
}
