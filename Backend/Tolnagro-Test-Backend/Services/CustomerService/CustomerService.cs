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

        public async Task<Customer> GetCustomerById(string id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            customer.IsHistoryChecked = false;
            await _customerRepository.UpdateCustomer(customer);
        }
        public async Task DeleteCustomer(string customerId)
        {
            await _customerRepository.DeleteCustomer(customerId);
        }

        public async Task<Address> AddAddress(string customerId, Address address)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new Exception($"Customer with id {customerId} was not found");
            }
            if (customer.Addresses == null)
            {
                customer.Addresses = new();
            }
            if (address.Id == null)
            {
                address.Id = Guid.NewGuid().ToString();
            }
            customer.Addresses.Add(address);
            customer.IsHistoryChecked = false;
            await _customerRepository.UpdateCustomer(customer);
            return address;
        }

        public async Task UpdateAddress(string customerId, Address address)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new Exception($"Customer with id {customerId} was not found");
            }
            if (customer.Addresses == null)
            {
                throw new Exception($"Address list was null");
            }
            var foundAddress = customer.Addresses.FirstOrDefault(x => x.Id == address.Id);
            if (foundAddress == null)
            {
                throw new Exception($"Address with id {address.Id} was not found");
            }
            for (int i = 0; i < customer.Addresses.Count; i++)
            {
                if (customer.Addresses[i].Id == address.Id)
                {
                    customer.Addresses[i] = address;
                    break;
                }
            }
            customer.IsHistoryChecked = false;
            await _customerRepository.UpdateCustomer(customer);
        }

        public async Task DeleteAddress(string customerId, string addressId)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new Exception($"Customer with id {customerId} was not found");
            }
            if (customer.Addresses == null)
            {
                return;
            }
            var removedCount = customer.Addresses.RemoveAll(x => x.Id == addressId);
            if (removedCount == 0)
            {
                return;
            }
            customer.IsHistoryChecked = false;
            await _customerRepository.UpdateCustomer(customer);
        }
    }
}
