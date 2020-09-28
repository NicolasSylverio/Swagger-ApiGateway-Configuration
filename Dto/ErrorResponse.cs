using System;

namespace Swagger.Gateway.Configuration.Dto
{
    public class ErrorResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}