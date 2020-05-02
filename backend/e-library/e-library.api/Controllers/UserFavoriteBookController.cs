using Elibrary.Application.Common.Controllers;
using Elibrary.Application.UserFavoriteBookArea.Queries.GetUserFavoriteBooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/favorites")]
    public class UserFavoriteBookController : BaseController
    {
        private const int PageSize = 10;

        //[HttpGet]
        //public async Task<ActionResult<UserFavoriteBooksViewModel>> GetPageAsync(int pageNumber = 1, int? pageSize = PageSize)
        //{            
        //    return await Mediator.Send(new GetUserFavoriteBooksQuery(CurrentUser.Id, pageNumber, pageSize.Value));
        //}
    }
}
