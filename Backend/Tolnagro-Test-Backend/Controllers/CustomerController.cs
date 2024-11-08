using Microsoft.AspNetCore.Mvc;
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

        [HttpPost(Name = nameof(CreateCustomer))]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
        {
            var result = await _customerService.CreateCustomer(customer);
            return Ok(result);
        }

        [HttpDelete(Name = nameof(DeleteCustomer))]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(string id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok();
        }

        [HttpPatch(Name = nameof(UpdateCustomer))]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
            return Ok();
        }
    }
}
