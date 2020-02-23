using elibrary.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace elibrary.api.Controllers
{
    [ApiController]
    [Route("favorites")]
    public class UserFavoriteBookController : ControllerBase
    {
        private readonly IFavoritesService _favoritesService;
        private const int PageSize = 10;

        public UserFavoriteBookController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageAsync(int pageNumber = 1, int? pageSize = null)
        {
            if (!pageSize.HasValue) 
                pageSize = PageSize;

            var model = await _favoritesService
                .GetPageAsync(pageNumber, pageSize.Value);

            return Ok(model);
        }
    }
}
