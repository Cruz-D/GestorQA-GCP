using GestorQA_GCP.Application.Abstractions.Persistence;
using GestorQA_GCP.Domain.Models;

namespace GestorQA_GCP.Infrastructure.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> entities = [];

    public Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        entities.Add(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = entities.FirstOrDefault(current => current.Id == id);

        if (entity is not null)
        {
            entities.Remove(entity);
        }

        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<T> result = entities;
        return Task.FromResult(result);
    }

    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        T? entity = entities.FirstOrDefault(current => current.Id == id);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var current = entities.FirstOrDefault(item => item.Id == entity.Id);

        if (current is not null)
        {
            entities.Remove(current);
        }

        entities.Add(entity);
        return Task.CompletedTask;
    }
}