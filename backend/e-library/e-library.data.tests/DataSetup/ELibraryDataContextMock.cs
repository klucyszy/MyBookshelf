using AutoFixture;
using Elibrary.Data.Context;
using Elibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_library.Data.tests.DataSetup
{
    public static class ELibraryDataContextMock
    {
        public static void SetupContext(
            DbContextOptions<ELibraryContext> options,
            Fixture fixture)
        {
            using var context = new ELibraryContext(options);

            int userId1 = fixture.Create<int>();
            int userId2 = fixture.Create<int>();

            User user1 = fixture.Build<User>()
                .With(x => x.Id, userId1)
                .Without(x => x.FavoriteBooks)
                .Without(x => x.BooksOnLoan)
                .Create();
            User user2 = fixture.Build<User>()
                .With(x => x.Id, userId2)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.FavoriteBooks)
                .Create();

            string isbn1 = fixture.Create<string>();
            string isbn2 = fixture.Create<string>();
            string isbn3 = fixture.Create<string>();
            string isbn4 = fixture.Create<string>();

            Book book1 = fixture.Build<Book>()
                .With(x => x.ISBN, isbn1)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book2 = fixture.Build<Book>()
                .With(x => x.ISBN, isbn2)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book3 = fixture.Build<Book>()
                .With(x => x.ISBN, isbn3)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book4 = fixture.Build<Book>()
                .With(x => x.ISBN, isbn4)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();

            context.Users.AddRange(user1, user2);

            context.SaveChanges();

        }
    }
}
