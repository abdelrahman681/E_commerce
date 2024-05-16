using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Domain.Specification;
using E_Commerce.Repositry.Specification;
using E_Commerce.Services.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Repositry
{
    public class GenericRepositry<TEntity, TKey> : IGenericReposity<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly E_CommerceDataContext _context;

        public GenericRepositry(E_CommerceDataContext  context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        

        public async Task<IEnumerable<TEntity>> GetAllAsync()=> await  _context.Set<TEntity>().ToListAsync();

        public  async Task<IEnumerable<TEntity>> GetAllwithspecififcationAsync(ISpecification<TEntity> specification)
        {
            return await Applayspec(specification).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey Id) =>( await _context.Set<TEntity>().FindAsync(Id))!;

        public async Task<TEntity> GetByIdwithspecificationAsync(ISpecification<TEntity> specification)

            => await Applayspec(specification).FirstOrDefaultAsync();

        public async Task<int> GetProductCountwithspecififcationAsync(ISpecification<TEntity> specification)
          => await Applayspec(specification).CountAsync();

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);


        private IQueryable<TEntity> Applayspec(ISpecification<TEntity> specification)
            => SpecificationEvaluator<TEntity, TKey>.QueryBuild(_context.Set<TEntity>(), specification);
    }
}
