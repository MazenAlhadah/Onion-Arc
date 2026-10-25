using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Onion.Api.Errors
{
    
    public class ApiResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int? statuscode,string? message=null)
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }

        private string? GetDefaultMessageForStatusCode(int? statuscode)
        {
            return statuscode switch
            {
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null
            };

        }

    }
}
