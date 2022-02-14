using Api_Customer_Domain.Entities;
using Api_Customer_Domain.ValuesObject;
using System.Threading.Tasks;

namespace Api_Customer_Domain.Contracts.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByDocument(Document document);
        Task<bool> DocumentExists(string documentNumber);
    }
}
