using Microsoft.EntityFrameworkCore;
using Polygon.App.Data.Entities;
using Polygon.App.Data.Interfaces;

namespace Polygon.App.Data
{
    public class PolygonDbContext : DbContext, IPolygonDbContext
    {
        public PolygonDbContext(DbContextOptions<PolygonDbContext> options)
            : base(options)
        {

        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message, ex);
            }
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
