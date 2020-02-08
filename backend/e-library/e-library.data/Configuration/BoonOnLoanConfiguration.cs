using elibrary.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace elibrary.data.Configuration
{
    public class BoonOnLoanConfiguration : IEntityTypeConfiguration<BookOnLoan>
    {
        public void Configure(EntityTypeBuilder<BookOnLoan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Relation R01
            builder
                .HasOne(e => e.User)
                .WithMany(c => c.BooksOnLoan)
                .HasForeignKey(f => f.UserId);

            // Relation R02
            builder
                .HasOne(e => e.Book)
                .WithMany(c => c.BooksOnLoan)
                .HasForeignKey(fk => fk.BookId);
        }
    }
}
