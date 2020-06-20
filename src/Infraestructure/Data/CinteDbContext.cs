using System.Reflection;
using Cinte.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinte.Infraestructure.Data
{
    public class CinteDbContext : DbContext
    {

        public CinteDbContext(DbContextOptions<CinteDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TipoDocumento> TipoDocumentos {get;set;}
    }
}