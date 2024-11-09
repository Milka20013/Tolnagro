using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task DeleteCustomer(string customerId);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(string id);
        Task UpdateCustomer(Customer customer);
    }
}