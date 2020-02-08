using AutoFixture;
using elibrary.data.Context;
using elibrary.data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace e_library.data.tests
{
    public class ELibraryContextTests : IDisposable
    {
        private readonly Fixture _fixture;
        private readonly ITestOutputHelper _testOutput;
        private readonly DbContextOptions<ELibraryContext> _options;

        public ELibraryContextTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _fixture = new Fixture();
            _options = new DbContextOptionsBuilder<ELibraryContext>()
                .UseInMemoryDatabase("testDB")
                .Options;

            SetupInMemoryContext(_options);
        }

        [Fact]
        public void Context_Returns_Correct_Result_For_Users_And_Books()
        {
            //Arrange
            using var context = new ELibraryContext(_options);
            
            //Act
            int usersCount = context.Users.Count();
            int booksCount = context.Books.Count();

            usersCount.Should().Be(2);
            booksCount.Should().Be(4);
        }

        public void Dispose()
        {
            using var context = new ELibraryContext(_options);
            context.Database.EnsureDeleted();
        }

        private void SetupInMemoryContext(
            DbContextOptions<ELibraryContext> options)
        {
            using var context = new ELibraryContext(options);

            Guid userId1 = _fixture.Create<Guid>();
            Guid userId2 = _fixture.Create<Guid>();
            _testOutput.WriteLine($"Users 1 ID: {userId1.ToString()}");

            User user1 = _fixture.Build<User>()
                .With(x => x.Id, userId1)
                .Without(x => x.FavoriteBooks)
                .Without(x => x.BooksOnLoan)
                .Create();
            User user2 = _fixture.Build<User>()
                .With(x => x.Id, userId2)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.FavoriteBooks)
                .Create();

            string isbn1 = _fixture.Create<string>();
            string isbn2 = _fixture.Create<string>();
            string isbn3 = _fixture.Create<string>();
            string isbn4 = _fixture.Create<string>();

            Book book1 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn1)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book2 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn2)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book3 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn3)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();
            Book book4 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn4)
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();

            context.Users.AddRange(user1, user2);
            context.Books.AddRange(book1, book2, book3, book4);
            
            context.SaveChanges();

        }
    }
}
