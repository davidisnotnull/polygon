using Polygon.App.Data.Entities;
using Polygon.App.Data.Interfaces;

namespace Polygon.App.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(IPolygonDbContext context)
        {
            _repositories = new Dictionary<Type, object>();
            Context = context;
        }

        public IPolygonDbContext Context { get; }
       
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(this);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
