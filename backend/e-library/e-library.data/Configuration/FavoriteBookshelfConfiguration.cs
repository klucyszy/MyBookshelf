using Elibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elibrary.Data.Configuration
{
    public class FavoriteBookshelfConfiguration : IEntityTypeConfiguration<Bookshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelf> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
