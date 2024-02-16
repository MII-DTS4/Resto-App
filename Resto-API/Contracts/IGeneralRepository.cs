using Resto_API.Data;

namespace Resto_API.Contracts
{
    public interface IGeneralRepository<TEntity>
    {
        RestoAppDbContext GetContext();
        IEnumerable<TEntity> GetAll();
        TEntity? GetByGuid(Guid guid);
        TEntity? Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
