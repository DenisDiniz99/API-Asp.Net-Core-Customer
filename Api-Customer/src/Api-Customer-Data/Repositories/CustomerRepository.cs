using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using Api_Customer_Domain.ValuesObject;
using System.Threading.Tasks;

namespace Api_Customer_Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApiContext contex) : base(contex) { }

        public Task<Customer> GetByDocument(Document document)
        {
            throw new System.NotImplementedException();
        }
    }
}
