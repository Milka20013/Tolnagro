﻿using Tolnagro_Test_Backend.Database;
using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Repositories.CustomerRepository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseService databaseService) : base(databaseService, "Customer")
        {
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return await GetById(id);
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await GetAll();
        }

        public async Task<List<Customer>> GetAllCustomersToHistoryCheck()
        {
            return await Get(x => !x.IsHistoryChecked);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await Create(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await Update(customer);
        }

        public async Task DeleteCustomer(string customerId)
        {
            await Delete(customerId);
        }
    }
}
