using Polygon.App.Data.Entities;
using System.Linq.Expressions;

namespace Polygon.App.Data.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets an entity by its id
        /// </summary>
        /// <param name="id">Guid id of entity</param>
        /// <returns>Entity</returns>
        T GetById(string id);

        /// <summary>
        /// Gets a list of all entities of a specific type
        /// </summary>
        /// <returns>Enumerated list of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets a collection of objects based upon a provided expression
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> whereClause);

        /// <summary>
        /// Gets a collection of untracked objects based upon a provided expression
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        IEnumerable<T> GetUntracked(Expression<Func<T, bool>> whereClause);

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity">Populated entity</param>
        T Add(T entity);

        /// <summary>
        /// Batch creates a list of entities
        /// </summary>
        /// <param name="entities">Enumerated list of entities</param>
        /// <remarks>
        /// This, with it's <c>Insert(T entity)</c> counterpart, is an example of parametric polymorphism, i.e.
        /// two methods with the same name in the same class that have differing method signatures
        /// </remarks>
        IEnumerable<T> Add(IEnumerable<T> entities);

        /// <summary>
        /// Updates a specific entity
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        T Update(T entityToUpdate);

        /// <summary>
        /// Batch updates a list of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<T> Update(IEnumerable<T> entities);

        /// <summary>
        /// Deletes a specific entity by its id
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Deletes a list of entities by their ids
        /// </summary>
        /// <param name="ids"></param>
        void Delete(IEnumerable<string> ids);

        /// <summary>
        /// Deletes a specific entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        void Delete(T entityToDelete);

        /// <summary>
        /// Deletes an enumerable list of entities
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);
    }
}
