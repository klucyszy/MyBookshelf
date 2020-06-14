using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Elibrary.Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Elibrary.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiModel(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiModelTransformerMiddleware>();
        }
    }

    public class ApiModelTransformerMiddleware : IDisposable
    {
        private readonly RequestDelegate _next;
        private MemoryStream _memoryStream;

        public ApiModelTransformerMiddleware(RequestDelegate next)
        {
            _next = next;
            _memoryStream = new MemoryStream();
        }

        public void Dispose()
        {
            if (_memoryStream != null)
                _memoryStream.Dispose();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Stream originalBody = httpContext.Response.Body;
            httpContext.Response.Body = _memoryStream;
            
            await _next(httpContext);

            if (httpContext.Response.StatusCode == 401 || httpContext.Response.StatusCode == 403)
            {
                await HandleUnauthorized(httpContext);
            }
            else
            {
                await HandleEndpointApiResponse(httpContext, originalBody);
            }
        }

        private async Task HandleEndpointApiResponse(HttpContext httpContext, Stream originalBody)
        {
            try
            {
                _memoryStream.Position = 0;
                StreamReader streamReader = new StreamReader(_memoryStream);
                string responseBody = await streamReader.ReadToEndAsync();
                ApiModel model = JsonConvert.DeserializeObject<ApiModel>(responseBody);
                httpContext.Response.StatusCode = model.HttpStatuscode;

                _memoryStream.Position = 0;
                await _memoryStream.CopyToAsync(originalBody);
            }
            finally
            {
                httpContext.Response.Body = originalBody;
            }
        }

        private async Task HandleUnauthorized(HttpContext httpContext)
        {
            ApiModel model = new ApiModel(httpContext.Response.StatusCode);
            model.Success = false;
            model.Error = "You are unauthorized";
            string responseBody = JsonConvert.SerializeObject(model);

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(responseBody);
        }
    }
}
