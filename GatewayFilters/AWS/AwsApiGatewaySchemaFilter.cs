using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Gateway.Configuration.GatewayFilters.AWS
{
    public class AwsApiGatewaySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Nullable = default;
            schema.ReadOnly = default;
            schema.WriteOnly = default;
        }
    }
}