using Elibrary.Application.Common.Interfaces;
using Elibrary.Data.Seed;
using Elibrary.Domain.Common;
using Elibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Elibrary.Data.Context
{
    public class ELibraryContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bookshelf> FavoriteBookshelves { get; set; }

        public ELibraryContext() { }
        public ELibraryContext(DbContextOptions<ELibraryContext> opts)
            : base(opts)
        {           
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = Guid.NewGuid().ToString();
                        entry.Entity.CreateDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = Guid.NewGuid().ToString();
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.CreateSampleData();

            base.OnModelCreating(builder);
        }
    }
}
