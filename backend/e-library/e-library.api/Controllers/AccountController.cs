using Elibrary.Application.AccountArea.Commands.AuthenticateWithGoogle;
using Elibrary.Application.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Route("api/authorize")]
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("google")]
        public async Task<ActionResult<AuthenticateWithGoogleResponse>> LoginWithGoogle([FromBody] AuthenticateWithGoogleCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
