using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Swagger.Gateway.Configuration.GatewayFilters.AWS
{
    public class AwsApiGatewayParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {

        }
    }
}
