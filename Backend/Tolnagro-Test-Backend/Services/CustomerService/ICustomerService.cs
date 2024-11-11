using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Address> AddAddress(string customerId, Address address);
        Task<Customer> CreateCustomer(Customer customer);
        Task DeleteAddress(string customerId, string addressId);
        Task DeleteCustomer(string customerId);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(string id);
        Task UpdateAddress(string customerId, Address address);
        Task UpdateCustomer(Customer customer);
    }
}