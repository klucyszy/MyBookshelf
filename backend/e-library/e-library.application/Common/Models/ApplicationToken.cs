using System;

namespace Elibrary.Application.Common.Models
{
    public class ApplicationToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
