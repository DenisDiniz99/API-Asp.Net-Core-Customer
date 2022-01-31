using Api_Customer_Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Api_Customer_Business.Contracts
{
    public interface ICustomerService
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Remove(Guid id);
    }
}
