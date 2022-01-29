using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Entities;

namespace Api_Customer_Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(ApiContext context) : base(context) { }
    }
}
