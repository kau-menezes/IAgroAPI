using IAgro.Domain.Models;

namespace IAgro.Application.Repositories;

public interface IBaseRepository<TEntity>
    where TEntity : BaseModel
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> Get(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
}