using Microsoft.EntityFrameworkCore;

namespace elibrary.data.Context
{
    public class ELibraryContext : DbContext
    {
        public ELibraryContext()
        {

        }

        public ELibraryContext(DbContextOptions<ELibraryContext> opts)
            : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ELibraryContext).Assembly);
        }
    }
}
