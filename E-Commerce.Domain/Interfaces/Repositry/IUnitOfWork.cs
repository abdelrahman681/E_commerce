using E_Commerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces.Repositry
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericReposity<TEntity, TKey> Reposity<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
