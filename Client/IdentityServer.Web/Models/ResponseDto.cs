using System.Collections.Generic;

namespace IdentityServer.Web.Models
{
    public class ResponseDto
    {
        public string DisplayMessage { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
}
