using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Gateway.Configuration.GatewayFilters.WSO2
{
    public class Wso2ApiGatewayParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
        }
    }
}