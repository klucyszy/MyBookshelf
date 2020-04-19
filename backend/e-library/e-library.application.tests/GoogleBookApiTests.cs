using Elibrary.Application.BooksApi;
using System.Threading.Tasks;
using Xunit;

namespace e_library.application.tests
{
    public class GoogleBookApiTests
    {
        [Fact]
        public async Task Test()
        {
            //Arrange
            var googleBookApi = new GoogleBooksService();

            //Act
            var tets = await googleBookApi.GetVolumes("test");

            //Assert
        }
    }
}
