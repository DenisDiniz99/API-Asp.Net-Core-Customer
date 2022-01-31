using Api_Customer_Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Api_Customer_Business.Contracts
{
    public interface IAddressService
    {
        Task Add(Address address);
        Task Update(Address address);
        Task Remove(Guid id);
    }
}
