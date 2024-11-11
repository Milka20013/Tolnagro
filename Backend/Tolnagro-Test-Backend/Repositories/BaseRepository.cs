using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using Tolnagro_Test_Backend.Database;
using Tolnagro_Test_Backend.Models;

namespace Tolnagro_Test_Backend.Repositories
{
    public abstract class BaseRepository<T> where T : RootModel
    {
        private string CollectionName { get; set; }
        protected readonly IMongoCollection<T> _collection;
        public BaseRepository(IDatabaseService databaseService, string collectionName)
        {
            CollectionName = collectionName;
            _collection = databaseService.Database.GetCollection<T>(CollectionName);
        }

        protected async Task<T> GetById(string id)
        {
            var cursor = await _collection.FindAsync(x => x.Id == id);
            return await cursor.FirstOrDefaultAsync();
        }

        protected async Task<List<T>> Get(Expression<Func<T, bool>> expression)
        {
            var cursor = await _collection.FindAsync(expression);
            return await cursor.ToListAsync();
        }

        protected async Task<List<T>> GetAll()
        {
            var cursor = await _collection.FindAsync(x => true);
            return await cursor.ToListAsync();
        }

        protected async Task<T> Create(T model)
        {
            ObjectId objectId = ObjectId.GenerateNewId();
            model.Id = objectId.ToString();
            await _collection.InsertOneAsync(model);
            return model;
        }

        protected async Task Update(T model)
        {
            await _collection.ReplaceOneAsync(x => x.Id == model.Id, model);
        }

        protected async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
