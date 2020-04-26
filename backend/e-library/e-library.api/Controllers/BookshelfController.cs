using Elibrary.Application.BookshelfsArea.Queries.GetBookshelf;
using Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList;
using Elibrary.Application.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/bookshelfs")]
    public class BookshelfController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetBookshelfsApiListModel>> GetUserBookshelfs()
        {
            return await Mediator.Send(new GetBookshelfsListQuery());
        }

        [HttpGet]
        [Route("{bookshelfId}")]
        public async Task<ActionResult<GetBookshelfApiModel>> GetBookshelf(string bookshelfId)
        {
            return await Mediator.Send(new GetBookshelfQuery(bookshelfId));
        }

        [HttpGet]
        [Route("search/{query}")]
        public async Task<ActionResult> SearchBookshelf(string query)
        {
            return Ok();
        }
    }
}
