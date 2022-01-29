using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Entities;

namespace Api_Customer_Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ApiContext contex) : base(contex) { }
    }
}
