using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Polygon.App.Data.Interfaces
{
    public interface IPolygonDbContext : IDisposable
    {
        /// <summary>
        /// Gets the Entity framework change tracker for access to added/modified entities
        /// </summary>
        ChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Gets the Entity Framework entity infrastructure data for an Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<T> Entry<T>(T entity) where T : class;

        /// <summary>
        /// Returns a DbSet instance for access to entities within the repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Saves changes to context
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
