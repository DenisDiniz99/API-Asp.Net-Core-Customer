using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using Api_Customer_Domain.ValuesObject;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<bool> DocumentExists(string documentNumber)
        {

            return await _dbSet.AnyAsync(c => c.Document.Number == documentNumber);
        }
    }
}
