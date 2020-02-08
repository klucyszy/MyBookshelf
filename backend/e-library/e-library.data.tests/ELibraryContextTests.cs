using AutoFixture;
using e_library.data.tests.DataSetup;
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

            ELibraryDataContextMock.SetupContext(_options, _fixture);
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
    }
}
