using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Swagger.Gateway.Configuration.GatewayFilters.AWS
{
    public class AwsApiGatewayOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Extensions.Add("x-amazon-apigateway-integration", new OpenApiObject
            {
                ["responses"] = new OpenApiObject
                {
                    ["default"] = new OpenApiObject
                    {
                        ["statusCode"] = new OpenApiString(context.ApiDescription.SupportedResponseTypes.FirstOrDefault()?.StatusCode.ToString() ?? "200"),
                        ["responseParameters"] = new OpenApiObject()                        
                    }
                },
                ["uri"] = new OpenApiString($"http://demo.swagger.execute-api.sa-east-1.amazonaws.com/{context.ApiDescription.RelativePath}"),
                ["passthroughBehavior"] = new OpenApiString("when_no_match"),
                ["httpMethod"] = new OpenApiString(context.ApiDescription.HttpMethod),
                ["type"] = new OpenApiString("http")
            });


        }
    }
}