using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Repositories.CustomerHistoryRepository
{
    public interface ICustomerHistoryRepository
    {
        Task CreateHistory(CustomerHistory history);
    }
}