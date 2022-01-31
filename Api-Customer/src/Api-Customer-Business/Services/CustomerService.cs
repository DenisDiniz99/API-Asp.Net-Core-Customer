using Api_Customer_Business.Contracts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using Api_Customer_Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Api_Customer_Business.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository, INotifier notifier) :base(notifier)
        {
            _repository = repository;
        } 


        public async Task Add(Customer customer)
        {
            if (!Validate(new CustomerValidator(), customer)) return;
            await _repository.Add(customer);
        }

        public async Task Remove(Guid id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(Customer customer)
        {
            if (!Validate(new CustomerValidator(), customer)) return;
            await _repository.Update(customer);
        }
    }
}
