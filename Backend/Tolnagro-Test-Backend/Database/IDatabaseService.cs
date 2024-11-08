using MongoDB.Driver;

namespace Tolnagro_Test_Backend.Database
{
    public interface IDatabaseService
    {
        IMongoDatabase Database { get; }
    }
}