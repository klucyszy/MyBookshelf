using Elibrary.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Elibrary.Application.Common.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private ApplicationUser _currentUser;
        public ApplicationUser CurrentUser => _currentUser ??= new ApplicationUser(HttpContext.User.Claims);

    }
}
