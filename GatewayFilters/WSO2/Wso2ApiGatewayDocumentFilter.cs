using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Gateway.Configuration.GatewayFilters.WSO2
{
    public class Wso2ApiGatewayDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument document, DocumentFilterContext context)
        {
            document.Extensions.Add("security", new OpenApiArray
            {
                new OpenApiObject
                {
                    ["default"] = new OpenApiArray{}
                }
            });

            // Remove /v1 of url path, for swagger wso2 json generator.
            OpenApiPaths newWsoUrlPaths = new OpenApiPaths();

            foreach (var path in document.Paths)
            {
                newWsoUrlPaths.Add
                (
                    path.Key.Replace("/v1", ""),
                    path.Value
                );
            }

            document.Paths = newWsoUrlPaths;
        }
    }
}