using System.Reflection;
using Orojas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Orojas.Infraestructure.Data
{
    public class OrojasDbContext : DbContext
    {

        public OrojasDbContext(DbContextOptions<OrojasDbContext> options) : base(options)
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