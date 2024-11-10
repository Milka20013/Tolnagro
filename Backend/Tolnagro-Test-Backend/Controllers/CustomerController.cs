﻿using Microsoft.AspNetCore.Mvc;
using Tolnagro_Test_Backend.DTOs;
using Tolnagro_Test_Backend.Models;
using Tolnagro_Test_Backend.Services.CustomerService;

namespace Tolnagro_Test_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(Name = nameof(GetAllCustomers))]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomers();
            return Ok(result);
        }

        [HttpGet("by-id", Name = nameof(GetCustomerById))]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            var result = await _customerService.GetCustomerById(id);
            return Ok(result);
        }

        [HttpPost(Name = nameof(CreateCustomer))]
        public async Task<ActionResult<Customer>> CreateCustomer(AddCustomerDTO customerDTO)
        {
            var result = await _customerService.CreateCustomer(new Customer() { Name = customerDTO.Name });
            return Ok(result);
        }

        [HttpDelete(Name = nameof(DeleteCustomer))]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok();
        }

        [HttpPatch(Name = nameof(UpdateCustomer))]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpPatch("add-address", Name = nameof(AddAddress))]
        public async Task<ActionResult> AddAddress(string customerId, Address address)
        {
            await _customerService.AddAddress(customerId, address);
            return Ok();
        }
    }
}
