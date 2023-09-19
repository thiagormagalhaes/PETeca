using Microsoft.EntityFrameworkCore;

namespace PETeca.Infra.Data
{
    public class PETecaContext : DbContext
    {
        public PETecaContext(DbContextOptions<PETecaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappingsAssemply = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(mappingsAssemply);

            base.OnModelCreating(modelBuilder);
        }
    }
}
