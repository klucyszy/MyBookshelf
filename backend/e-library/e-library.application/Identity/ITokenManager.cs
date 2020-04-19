using Elibrary.Application.Common.Models;
using System.Threading.Tasks;

namespace Elibrary.Application.Identity
{
    public interface ITokenManager
    {
        Task<GooglePayload> ValidateBearerTokenAsync(string authCode);
        ApplicationToken GenerateBearerTokenAsync(GooglePayload payload);
    }
}
