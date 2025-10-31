using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Data;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly RestorantDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(RestorantDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public void DeleteAsync(T entity)
        {
              entity.IsDeleted = true;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet);
        }


        public async Task<T?> GetById(int Id)
        {
            return await (_dbSet.FindAsync(Id));
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
           _context.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
