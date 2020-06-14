using AutoFixture;
using e_library.Data.tests.DataSetup;
using Elibrary.Data.Context;
using Elibrary.Domain.Entities;
using Elibrary.Data.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace e_library.Data.tests
{
    public class RepositoryTests: IDisposable
    {
        private readonly Fixture _fixture;
        private readonly DbContextOptions<ELibraryContext> _options;

        public RepositoryTests()
        {
            _fixture = new Fixture();
            _options = new DbContextOptionsBuilder<ELibraryContext>()
                .UseInMemoryDatabase("testDB")
                .Options;

            ELibraryDataContextMock.SetupContext(_options, _fixture);
        }

        [Fact]
        public void GetFirstOrDefaultBy_Type_Returns_Correct_Result()
        {
            //Arrange
            //using var context = new ELibraryContext(_options);
            //var DataRepository = new DataRepository<Book>(context);
            ////var book = context.Books.FirstOrDefault();

            ////Act
            //Book result = DataRepository.GetFirstOrDefaultBy(x => x.ISBN == book.ISBN);

            ////Assert
            //book.Author.Should().Equals(result.Author);

        }

        [Fact]
        public void GetFirstOrDefaultBy_Returns_Default_Result()
        {
            //Arrange
            using var context = new ELibraryContext(_options);
            var DataRepository = new DataRepository<Book>(context);
            var book = _fixture.Build<Book>()
                .Without(x => x.BooksOnLoan)
                .Without(x => x.UseFavoriteBooks)
                .Create();

            //Act
            Book result = DataRepository.GetFirstOrDefaultBy(x => x.ISBN == book.ISBN);

            //Assert
            result.Should().BeNull();

        }

        public void Dispose()
        {
            using var context = new ELibraryContext(_options);
            context.Database.EnsureDeleted();
        }
    }
}
