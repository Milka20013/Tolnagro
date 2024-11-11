using Tolnagro_Test_Backend.Database;
using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Repositories.CustomerHistoryRepository
{
    public class CustomerHistoryRepository : BaseRepository<CustomerHistory>, ICustomerHistoryRepository
    {
        public CustomerHistoryRepository(IDatabaseService databaseService) : base(databaseService, "CustomerHistory")
        {

        }
        public async Task CreateHistory(CustomerHistory history)
        {
            await Create(history);
        }
    }
}
