using MongoDB.Driver;

namespace Tolnagro_Test_Backend.Database
{
    public class DatabaseService : IDatabaseService
    {
        public IMongoDatabase Database { get; }
        public DatabaseService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DBConnection");
            if (connectionString == null)
            {
                throw new Exception("DB connection string is not set");
            }
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            Database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}
