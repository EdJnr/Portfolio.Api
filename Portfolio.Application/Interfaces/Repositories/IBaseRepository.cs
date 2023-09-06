using MongoDB.Bson;
using System;

namespace Portfolio.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> Query(string ComparisonField, string ComparisonValue);

        Task<T> GetByIdAsync(ObjectId id);

        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(ObjectId id, T document);

        Task<bool> DeleteAsync(ObjectId id);
    }
}
