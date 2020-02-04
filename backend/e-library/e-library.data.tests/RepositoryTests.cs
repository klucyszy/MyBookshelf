using AutoFixture;
using elibrary.data.Context;
using elibrary.data.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace e_library.data.tests
{
    public class RepositoryTests
    {
        private readonly Fixture _fixture;
        private readonly DbContextOptions<ELibraryContext> _options;

        public RepositoryTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _options = new DbContextOptionsBuilder<ELibraryContext>()
                .UseInMemoryDatabase("testDB")
                .Options;

            SetupInMemoryContext(_options);
        }

        [Fact]
        public void Get_All_Returns_Correct_Result_Users()
        {
            //Arrange
            using var context = new ELibraryContext(_options);
            //Act
            int result = context.Users.Count();

            result.Should().Be(2);



            //Assert
        }

        private void SetupInMemoryContext(
            DbContextOptions<ELibraryContext> options)
        {
            using var context = new ELibraryContext(options);

            Guid userId_1 = _fixture.Create<Guid>();
            Guid userId_2 = _fixture.Create<Guid>();

            User user_1 = _fixture.Build<User>()
                .With(x => x.Id, userId_1)
                .Create();
            User user_2 = _fixture.Build<User>()
                .With(x => x.Id, userId_2)
                .Create();

            string isbn1 = _fixture.Create<string>();
            string isbn2 = _fixture.Create<string>();
            string isbn3 = _fixture.Create<string>();
            string isbn4 = _fixture.Create<string>();

            Book book1 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn1)
                .Create();
            Book book2 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn2)
                .Create();
            Book book3 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn3)
                .Create();
            Book book4 = _fixture.Build<Book>()
                .With(x => x.ISBN, isbn4)
                .Create();

            context.Users.AddRange(user_1, user_2);
            context.Books.AddRange(book1, book2, book3, book4);
            context.SaveChanges();
        }
    }
}
