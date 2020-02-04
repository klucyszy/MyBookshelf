using elibrary.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elibrary.data.Configuration
{
    public class FavoriteBookConfiguration : IEntityTypeConfiguration<UserFavoriteBook>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteBook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Comment)
                .HasMaxLength(512);

            // Relation R3
            builder.HasOne(e => e.User)
                .WithMany(c => c.FavoriteBooks)
                .HasForeignKey(fk => fk.UserId);

            // Relation R4
            builder.HasOne(e => e.Book)
                .WithMany(e => e.UseFavoriteBooks)
                .HasForeignKey(fk => fk.BookISBN);
        }
    }
}
