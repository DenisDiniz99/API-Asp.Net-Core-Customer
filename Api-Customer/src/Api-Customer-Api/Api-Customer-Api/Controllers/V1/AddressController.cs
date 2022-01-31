using Api_Customer_Api.Controllers;
using Api_Customer_Api.ViewModels;
using Api_Customer_Business.Contracts;
using Api_Customer_Domain.Contracts.Repositories;
using Api_Customer_Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Customer_Api.Extensions
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversiion}/{controller}")]
    public class AddressController : BaseController
    {
        private readonly IAddressService _service;
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        public AddressController(INotifier notifier,
                                    IAddressService service,
                                    IAddressRepository repository,
                                    IMapper mapper) : base(notifier)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressViewModel>>> Get()
        {
            return ResponseGet(_mapper.Map<IEnumerable<AddressViewModel>>(await _repository.GetAll()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> Get(Guid id)
        {
            return ResponseGet(_mapper.Map<AddressViewModel>(await _repository.GetById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InvalidModelError(ModelState);
                return ResponseError();
            }


            await _service.Add(_mapper.Map<Address>(model));

            return ResponsePost(model);
        }

        [HttpPut]
        public async Task<ActionResult<AddressViewModel>> Put(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InvalidModelError(ModelState);
                return ResponseError();
            }

            if (!await Exists(model.Id))
            {
                Notify("Endereço não encontrado");
                return ResponsePut();
            }

            await _service.Update(_mapper.Map<Address>(model));

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