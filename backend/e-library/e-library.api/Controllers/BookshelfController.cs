using Elibrary.Application.BookshelfsArea.Command.AddFavoriteBookshelf;
using Elibrary.Application.BookshelfsArea.Command.DeleteFavoriteBookshelf;
using Elibrary.Application.BookshelfsArea.Queries.GetBookshelf;
using Elibrary.Application.BookshelfsArea.Queries.GetBookshelfsList;
using Elibrary.Application.Common.Controllers;
using Elibrary.Application.Common.Models;
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
            return await Mediator.Send(new GetBookshelfsListQuery(CurrentUser.Id, option));
        }

        /// <summary>
        /// Add bookshelf to user favorite booshelfs.
        /// </summary>
        /// <param name="bookshelfId">BookshelfId (integer).</param>
        /// <returns>Determines if request was successful.</returns>
        [HttpPost("favorites/{bookshelfId}")]
        public async Task<ActionResult<ApiModel>> AddUserFavoriteBookshelf(int bookshelfId)
        {
            return await Mediator.Send(new AddFavoriteBookshelfCommand(CurrentUser.Id, bookshelfId));
        }

        /// <summary>
        /// Remove bookshelf from user favorite bookshelfs.
        /// </summary>
        /// <param name="bookshelfId">BookshelfId (integer).</param>
        /// <returns>Determines if request was successful.</returns>
        [HttpDelete("favorites/{bookshelfId}")]
        public async Task<ActionResult<ApiModel>> RemoveUserFavoriteBookshelf(int bookshelfId)
        {
            return await Mediator.Send(new DeleteFavoriteBookshelfCommand(bookshelfId, CurrentUser.Id));
        }

        /// <summary>
        /// Get bookshelf.
        /// </summary>
        /// <param name="bookshelfId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{bookshelfId}")]
        public async Task<ActionResult<GetBookshelfApiModel>> GetBookshelf(string bookshelfId)
        {
            return await Mediator.Send(new GetBookshelfQuery(bookshelfId));
        }
    }
}
