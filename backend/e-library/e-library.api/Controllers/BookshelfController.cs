using Elibrary.Application.BookshelfsArea.Queries.GetBookshelf;
using Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList;
using Elibrary.Application.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("api/bookshelfs")]
    public class BookshelfController : BaseController
    {
        /// <summary>
        /// Get user bookshelfs.
        /// </summary>
        /// <param name="option">Option which determines the bookshelfs returned. Default value is ALL.
        ///     
        ///     BASE: Favorites, Purchased, To read, Reading now, Have read.
        ///     CUSTOM: User custom bookshelfs created.
        ///     OTHERS: Reviewed, Recently viewed, My Google eBooks, Browsing history
        ///     FAVORITES: Added to favorite bookshelfs.
        ///     
        /// </param>
        /// <returns>Returns user bookshelfs based on selected option.</returns>
        /// <remarks>
        /// Sample request:
        ///     GET api/bookshelfs?option=ALL
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<GetBookshelfsApiListModel>> GetUserBookshelfs(GetBookshelfsListQuery.BookshelfsOption option = GetBookshelfsListQuery.BookshelfsOption.All)
        {
            return await Mediator.Send(new GetBookshelfsListQuery(option));
        }

        [HttpPost("favorites/{bookshelfId}")]
        public async Task<ActionResult<GetBookshelfsApiListModel>> AddUserFavoriteBookshelf(string bookshelfId)
        {
            return Ok();
        }

        [HttpDelete("favorites/{bookshelfId}")]
        public async Task<ActionResult<GetBookshelfsApiListModel>> RemoveUserFavoriteBookshelf(string bookshelfId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{bookshelfId}")]
        public async Task<ActionResult<GetBookshelfApiModel>> GetBookshelf(string bookshelfId)
        {
            return await Mediator.Send(new GetBookshelfQuery(bookshelfId));
        }
    }
}
