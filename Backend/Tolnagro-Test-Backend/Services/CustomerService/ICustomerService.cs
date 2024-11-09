using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Services.CustomerService
{
    public interface ICustomerService
    {
        Task AddAddress(string customerId, Address address);
        Task<Customer> CreateCustomer(Customer customer);
        Task DeleteCustomer(string customerId);
        Task<List<Customer>> GetAllCustomers();
        Task UpdateCustomer(Customer customer);
    }
}