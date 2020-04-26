using Newtonsoft.Json;
using System;

namespace Elibrary.Application.Common.Models
{
    public class ApiModel
    {
        public ApiModel()
        {
            Success = true;
        }
        
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; } 
        
        public static TApiModel NotFound<TApiModel>() where TApiModel : ApiModel
        {
            TApiModel model = (TApiModel)Activator.CreateInstance(typeof(TApiModel));
            model.Error = "Not found";
            model.Success = false;

            return model;
        }
    }
}
