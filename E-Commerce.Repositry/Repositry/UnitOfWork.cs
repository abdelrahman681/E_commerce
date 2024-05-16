using E_Commerce.Domain.Entity;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Services.DataContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Repositry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Hashtable _hashtable;
        private readonly E_CommerceDataContext _context;

        public UnitOfWork(E_CommerceDataContext context)
        {
            _context = context;
            _hashtable = new Hashtable();
        }
        public async Task<int> CompleteAsync()=> await  _context.SaveChangesAsync();
        
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
  

        public IGenericReposity<TEntity, TKey> Reposity<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TypeName= typeof(TEntity).Name;
            if (_hashtable.ContainsKey(TypeName))
                return (_hashtable[TypeName] as IGenericReposity<TEntity, TKey>)!;

            var repo = new GenericRepositry<TEntity, TKey>(_context);
            _hashtable.Add(TypeName, repo); 
            return repo;
          
        }
    }
}
