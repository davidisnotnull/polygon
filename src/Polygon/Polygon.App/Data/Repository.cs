using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Polygon.App.Data.Entities;
using Polygon.App.Data.Interfaces;

namespace Polygon.App.Data
{
    public sealed class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T GetById(string id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereClause)
        {
            return _unitOfWork.Context.Set<T>().Where(whereClause).AsEnumerable();
        }

        public IEnumerable<T> GetUntracked(Expression<Func<T, bool>> whereClause)
        {
            return _unitOfWork.Context.Set<T>().Where(whereClause).AsNoTracking().AsEnumerable();
        }

        public T Add(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _unitOfWork.Context.Set<T>().Add(entity);

            return entity;
        }

        public IEnumerable<T> Add(IEnumerable<T> entities)
        {
            var baseEntities = entities as T[] ?? entities.ToArray();

            foreach (var entity in baseEntities)
            {
                Add(entity);
            }

            return baseEntities;
        }

        public T Update(T entityToUpdate)
        {
            ArgumentNullException.ThrowIfNull(entityToUpdate);

            _unitOfWork.Context.Entry(entityToUpdate).State = EntityState.Modified;

            return entityToUpdate;
        }

        public IEnumerable<T> Update(IEnumerable<T> entities)
        {
            var baseEntities = entities as T[] ?? entities.ToArray();

            foreach (var entity in baseEntities)
            {
                Update(entity);
            }

            return baseEntities;
        }

        public void Delete(string id)
        {
            Delete(GetById(id));
        }

        public void Delete(IEnumerable<string> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        public void Delete(T entityToDelete)
        {
            ArgumentNullException.ThrowIfNull(entityToDelete);

            _unitOfWork.Context.Set<T>().Remove(entityToDelete);
        }

        public void Delete(IEnumerable<T> entities)
        {
            var baseEntities = entities as T[] ?? entities.ToArray();

            foreach (var entity in baseEntities)
            {
                Delete(entity);
            }
        }
    }
}
