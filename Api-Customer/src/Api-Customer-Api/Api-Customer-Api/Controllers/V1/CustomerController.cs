using Api_Customer_Api.ViewModels;
using Api_Customer_Business.Contracts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Customer_Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/{controller}")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerController(INotifier notifier,
                                    ICustomerService service,
                                    ICustomerRepository repository,
                                    IMapper mapper) : base(notifier)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> Get()
        {
            return ResponseGet(_mapper.Map<IEnumerable<CustomerViewModel>>(await _repository.GetAll()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerViewModel>> Get(Guid id)
        {
            return ResponseGet(_mapper.Map<CustomerViewModel>(await _repository.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Post(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InvalidModelError(ModelState);
                return ResponseError();
            }

            
            await _service.Add(_mapper.Map<Customer>(model));

            return ResponsePost(model);
        }


        
        [HttpPut]
        public async Task<ActionResult<CustomerViewModel>> Put(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InvalidModelError(ModelState);
                return ResponseError();
            }

            if (!await Exists(model.Id))
            {
                Notify("Cliente não encontrado");
                return ResponsePut();
            }

            await _service.Update(_mapper.Map<Customer>(model));

            return ResponsePut();
        }


        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CustomerViewModel>> Delete(Guid id)
        {
            if (!await Exists(id))
            {
                Notify("Cliente não encontrado");
                return ResponseDelete(id);
            }

            await _service.Remove(id);

            return ResponseDelete(id);
        }





        private async Task<bool> Exists(Guid id)
        {
            var result = _mapper.Map<CustomerViewModel>(await _repository.GetById(id));
            if (result == null) return false;
            return true;
        }
    }
}
