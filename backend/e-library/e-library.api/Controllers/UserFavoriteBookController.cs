using Elibrary.Application.Common.Controllers;
using Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Authorize]
    [Route("favorites")]
    public class UserFavoriteBookController : BaseController
    {
        private readonly IMediator _mediator;
        private const int PageSize = 10;

        public UserFavoriteBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserFavoriteBooksViewModel>> GetPageAsync(int pageNumber = 1, int? pageSize = null)
        {
            
            return await _mediator.Send(new GetUserFavoriteBooksQuery());

            //if (!pageSize.HasValue) 
            //    pageSize = PageSize;

            //var model = await _favoritesService
            //    .GetPageAsync(pageNumber, pageSize.Value);

            //return Ok(model);
        }
    }
}
