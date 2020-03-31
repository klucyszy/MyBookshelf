using Elibrary.Application.AccountArea.Queries;
using Elibrary.Application.Common.Controllers;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Elibrary.Api.Controllers
{
    [Route("api/authorize")]
    public class AccountController : BaseController
    {
        public AccountController()
        {
        }

        [HttpGet]
        [Route("google")]
        public async Task<ActionResult> LoginWithGoogle([FromBody] AuthenticateGoogleTokenRequest request)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Token, new GoogleJsonWebSignature.ValidationSettings());

            return Ok();
        }
    }
}
