using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Gateway.Configuration.GatewayFilters.WSO2
{
    public class Wso2ApiGatewaySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Nullable = default;
            schema.ReadOnly = default;
            schema.WriteOnly = default;
        }
    }
}