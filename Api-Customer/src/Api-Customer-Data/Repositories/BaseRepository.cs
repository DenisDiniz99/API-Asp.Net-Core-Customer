using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Customer_Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: Entity, new()
    {
        protected readonly ApiContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ApiContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await SaveChange();
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChange();
        }

        public virtual async Task Remove(Guid id)
        {
            _dbSet.Remove(new T { Id = id });
            await SaveChange();
        }


        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        

        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }

        

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
