using Microsoft.EntityFrameworkCore;

namespace elibrary.data.Context
{
    public class ELibraryContext : DbContext
    {
        public ELibraryContext(DbContextOptions<ELibraryContext> opts)
            : base(opts)
        {

        }
    }
}
