using MongoDB.Bson;
using MongoDB.Driver;
using Portfolio.Application.Interfaces.Repositories;

namespace Portfolio.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(string collection)
        {
            string ConnectionString = "mongodb+srv://EdwardAmarteyJunior:owgIcMqcol77FoSP@portfolio.icfzdeo.mongodb.net/?retryWrites=true&w=majority";

            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase("Portfolio");

            _collection = database.GetCollection<T>(collection);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            if (filter != null)
            {
                await _collection.DeleteManyAsync(filter);
                return true;
            }

            return false;
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var results = await _collection.Find(_ => true).ToListAsync();

            return results;
        }

        public async Task<IReadOnlyList<T>> Query(string ComparisonField, string ComparisonValue)
        {
            var filter = Builders<T>.Filter.Eq(ComparisonField, ComparisonValue);

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateAsync(ObjectId id, T document)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            if (filter != null)
            {
                await _collection.ReplaceOneAsync(filter, document);
                return true;
            }

            return false;
        }
    }
}
