using Newtonsoft.Json;
using System;

namespace Elibrary.Application.Common.Models
{
    public class ApiModel
    {
        public ApiModel(int statusCode = 200)
        {
            Success = true;
            HttpStatuscode = statusCode;
        }
        
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
        public int HttpStatuscode { get; set; }

        public static ApiModel Ok()
        {
            return new ApiModel();
        }

        public static ApiModel Created()
        {
            return new ApiModel(201);
        }
        
        public static ApiModel NotFound()
        {
            ApiModel model = new ApiModel(404);
            model.Error = "Not found";
            model.Success = false;

            return model;
        }

        public static TApiModel NotFound<TApiModel>() where TApiModel : ApiModel
        {
            TApiModel model = (TApiModel)Activator.CreateInstance(typeof(TApiModel), 404);
            model.Error = "Not found";
            model.Success = false;

            return model;
        }
    }
}
