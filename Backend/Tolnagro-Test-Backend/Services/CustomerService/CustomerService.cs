using Tolnagro_Test_Backend.Models;
using Tolnagro_Test_Backend.Repositories.CustomerRepository;

namespace Tolnagro_Test_Backend.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }
        public async Task DeleteCustomer(string customerId)
        {
            await _customerRepository.DeleteCustomer(customerId);
        }
    }
}
