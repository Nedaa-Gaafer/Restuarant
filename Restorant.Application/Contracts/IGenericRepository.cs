using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IQueryable<T>> GetAllAsync();
        public Task<T> CreateAsync( T entity);
        public Task<T> GetById(int Id);
        public Task<T> Update(T entity);
        public void DeleteAsync(T entity);
        public Task<int> SaveChangesAsync();
    }
}
