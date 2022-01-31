using Api_Customer_Data.Contexts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;

namespace Api_Customer_Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApiContext context) : base(context) { }
    }
}
