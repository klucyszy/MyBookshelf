using Elibrary.Application.BooksArea.Queries.GetBooks;
using Elibrary.Application.BooksArea.Queries.SearchBooks;
using Elibrary.Application.Common.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : BaseController
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<GetAllUserVolumesApiModel>> GetUserBooks([FromQuery] GetBooksQueryRequest request)
        {
            return await Mediator.Send(new GetAllUserVolumesListQuery(request, CurrentUser.Id));
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[HttpGet]
        //[Route("search")]
        //public async Task<ActionResult<SearchBooksViewModel>> SearchBooks(
        //    [Required, MinLength(3)] string query = null)
        //{
        //    return await Mediator.Send(new SearchBooksQuery(CurrentUser.Id, query));
        //}
    }
}
