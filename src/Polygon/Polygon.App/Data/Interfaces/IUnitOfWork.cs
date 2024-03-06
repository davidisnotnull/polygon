using Polygon.App.Data.Entities;

namespace Polygon.App.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPolygonDbContext Context { get; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;

        int Commit();
    }
}
