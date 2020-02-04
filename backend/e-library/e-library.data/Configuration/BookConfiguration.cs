using elibrary.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elibrary.data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.ISBN);

            builder.Property(x => x.Author)
                .IsRequired();
            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x => x.Category)
                .IsRequired();
        }
    }
}
