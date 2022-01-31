using Api_Customer_Business.Contracts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using Api_Customer_Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Api_Customer_Business.Services
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository, INotifier notifier) : base(notifier)
        {
            _repository = repository;
        }


        public async Task Add(Address address)
        {
            if (!Validate(new AddressValidator(), address)) return;
            await _repository.Add(address);
        }

        public async Task Remove(Guid id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(Address address)
        {
            if (!Validate(new AddressValidator(), address)) return;
            await _repository.Update(address);
        }
    }
}
