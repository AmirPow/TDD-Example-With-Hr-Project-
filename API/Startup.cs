using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text.Json.Serialization;
using HR.Framework.AssemblyHelper;
using HR.Framework.Core.DependencyInjection;
using HR.Framework.Core.Persistence;
using HR.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var assemblyDiscovery = new AssemblyDiscovery("HR*.dll");
            var registrars = assemblyDiscovery.DiscoverInstance<IRegistrar>("HR").ToList();
            foreach (var registrar in registrars)
            {
                registrar.Register(services, assemblyDiscovery); ;
            }
            services.AddDbContext<IDbContext, HRDbContext>(op =>
            {
                op.UseSqlServer("Data Source=localhost;Initial Catalog=HR;Integrated Security=True");

            });




            var mvcBuilder = services.AddMvc(option =>
                                    {
                                        option.EnableEndpointRouting = false;
                                        option.Filters.Add(new ActiveUserFilter());
                                    }
                )
                                .AddNewtonsoftJson(o =>
                                {
                                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                                })
                                .AddJsonOptions(options =>
                                {
                                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                                });




            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR API", Version = "v1" });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.DescribeAllParametersInCamelCase();
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                    c.SchemaFilter<RequireValueTypePropertiesSchemaFilter>(true);
                    c.MapType<Stream>(() => new OpenApiSchema { Type = "file" });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Of HR");
                c.RoutePrefix = string.Empty;
            });



            app.UseSwaggerUI(c =>
                            {
                                c.SwaggerEndpoint("v1/swagger.json", "HR V1");
                                c.DocExpansion(DocExpansion.None);
                            });



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal class ActiveUserFilter : IFilterMetadata
    {
    }
}
