using elibrary.api.Utils.Models;
using elibrary.data.Entities;
using elibrary.data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace elibrary.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserFavoriteBookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        private const int PageSize = 10;

        public UserFavoriteBookController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int? pageSize = null)
        {
            if (!pageSize.HasValue) 
                pageSize = PageSize;

            var books = _repository
                .GetAll(pageNumber, pageSize.Value)
                .ToList();
            var booksCount = _repository.Count();
            var lastPage = (booksCount / pageSize.Value) % pageSize.Value == 1
                ? (booksCount / pageSize.Value)
                : (booksCount / pageSize.Value) + 1;

            var model = new PaginationModel<Book>
            {
                Data = books,
                PageNumber = pageNumber,
                PageSize = pageSize.Value,
                LastPage = lastPage
            };

            return Ok(model);
        }

    }
}
