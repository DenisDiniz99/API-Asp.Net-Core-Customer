using Api_Customer_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Customer_Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(Guid id);
        Task<int> SaveChange();
    }
}
