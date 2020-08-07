using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AlgorithmsAPI.Web.Extensions
{
    public static class SwaggerExtensions
    {
        private static void IncludeComments(this SwaggerGenOptions options)
        {
            string[] documentationXmls = AppDomain.CurrentDomain.GetAssemblies()
               .Where(x => x.FullName.StartsWith("AlgorithmsAPI"))
               .Select(x => $"{x.FullName.Split(',')[0]}.xml")
               .Select(x => Path.Combine(AppContext.BaseDirectory, x))
               .Where(File.Exists)
               .ToArray();

            foreach (string xml in documentationXmls)
                options.IncludeXmlComments(xml);
        }

        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ALGORITHMS API",
                        Version = "v1",
                    });

                c.DescribeAllEnumsAsStrings();

                //dodanie dokumentacji xml
                c.IncludeComments();
            });
        }

        internal static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ALGORITHMS API V1"); });
        }
    }
}