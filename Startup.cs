using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swagger.Gateway.Configuration.GatewayFilters.AWS;
using Swagger.Gateway.Configuration.GatewayFilters.WSO2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Swagger.Gateway.Configuration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc
                (
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Api Gateway - Swagger Configuration",
                        Version = "1.0",
                        Description = "Application with examples of automatic configuration of Api Gateway, from the swagger generated by the api.",
                        Contact = new OpenApiContact
                        {
                            Email = "nicolas_sylveriopereira@hotmail.com",
                            Name = "Nicolas Sylverio",
                            Url = new Uri("https://github.com/NicolasSylverio/Swagger-ApiGateway-Configuration")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under MIT",
                            Url = new Uri("https://github.com/NicolasSylverio/Swagger-ApiGateway-Configuration/blob/master/LICENSE"),
                        }
                    }
                );

                var commentFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentFilePath = Path.Combine(AppContext.BaseDirectory, commentFileName);
                options.IncludeXmlComments(commentFilePath);
                options.UseInlineDefinitionsForEnums();

                options.AddServer(new OpenApiServer
                {
                    Url = "https://localhost:4400",
                    Description = "Url Servidor Gateway",
                    Variables = new Dictionary<string, OpenApiServerVariable>()
                });

                #region Apigee

                #endregion

                #region Azure Api Gateway Filters

                #endregion

                #region Aws Api Gateway Filters

                //options.DocumentFilter<AwsApiGatewayDocumentFilter>();
                //options.OperationFilter<AwsApiGatewayOperationFilter>();
                //options.SchemaFilter<AwsApiGatewaySchemaFilter>();
                //options.ParameterFilter<AwsApiGatewayParameterFilter>();

                #endregion

                #region WSO2 Api Gateway Filters

                //options.DocumentFilter<Wso2ApiGatewayDocumentFilter>();
                //options.OperationFilter<Wso2ApiGatewayOperationFilter>();
                //options.SchemaFilter<Wso2ApiGatewaySchemaFilter>();
                //options.ParameterFilter<Wso2ApiGatewayParameterFilter>(); 

                //options.AddSecurityDefinition("default", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        Implicit = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri("https://localhost:4400/auth"),
                //            Scopes = new Dictionary<string, string>()
                //        }
                //    }
                //});

                #endregion
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs - Api gateway Configuration Demo");
            });
        }


    }
}
