//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;
//using Newtonsoft.Json;
//using Swashbuckle.AspNetCore.SwaggerUI;
//using System.IO;
//using System.Text.Json.Serialization;
//using HR.Framework.Core.DependencyInjection;
//using HR.Framework.Core.Persistence;
//using HR.Framework.Facade;
//using Microsoft.AspNetCore.Identity;

//namespace API
//{
//    public class Startup2
//    {
//        private readonly IWebHostEnvironment env;

//        public Startup(IConfiguration configuration, IWebHostEnvironment env)
//        {
//            Configuration = configuration;
//            this.env = env;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            var assemblyHelper = new AssemblyHelper(nameof(HR));
//            services.AddHttpContextAccessor();
//            services.AddTransient<IUserManager, UserManager<>>();
//            services.AddSingleton<ITempFileIdGenerator, TempFileIdGenerator>();
//            services.AddSingleton<IDataManagement, DataManagement>();
//            Registrar(services, assemblyHelper);


//            var mvcBuilder = services.AddMvc(option =>
//                    {
//                        option.EnableEndpointRouting = false;
//                        option.Filters.Add(new ActiveUserFilter());
//                    }


//                )
//                .AddNewtonsoftJson(o =>
//                {
//                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
//                })
//                .AddJsonOptions(options =>
//                {
//                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//                });

//            AddControllers(assemblyHelper, mvcBuilder);

//            mvcBuilder.AddControllersAsServices();

//            services.AddCors(o => o.AddPolicy("CrossDomainPolicy",
//                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR API", Version = "v1" });

//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                {
//                    Description =
//                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey
//                });
//                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
//                c.DescribeAllParametersInCamelCase();
//                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//                {
//                     {
//                            new OpenApiSecurityScheme
//                            {
//                                     Reference = new OpenApiReference
//                                     {
//                                            Type = ReferenceType.SecurityScheme,
//                                            Id = "Bearer"
//                                     },
//                                     Scheme = "oauth2",
//                                     Name = "Bearer",
//                                     In = ParameterLocation.Header,

//                            },
//                            new List<string>()
//                     }
//                });
//                c.SchemaFilter<RequireValueTypePropertiesSchemaFilter>(true);
//                c.OperationFilter<FileResultContentTypeOperationFilter>();
//                c.MapType<Stream>(() => new OpenApiSchema { Type = "file" });
//            });

//            services.AddAuthentication("Bearer")
//                .AddIdentityServerAuthentication(options =>
//                {
//                    options.Authority = "http://identity.shonizcloud.ir/identity/";
//                    options.RequireHttpsMetadata = false;
//                    options.ApiName = "HRMS Api";
//                    options.SaveToken = true;

//                });

//            services.AddTransient<FileApiClient>(a =>
//            {
//                var client = new FileApiClient()
//                {
//                    BaseAddress = new Uri(Configuration.GetSection("DataManagementSystemConfiguration").GetSection("ApiAddress").Value),
//                    Token = Configuration.GetSection("DataManagementSystemConfiguration").GetSection("Token").Value,
//                    ProgramId = Configuration.GetSection("DataManagementSystemConfiguration").GetSection("ProgramId").Value
//                };
//                return client;
//            });


//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            app.UseAllElasticApm(Configuration);
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                //changed place of migration
//                var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
//                var context = serviceScope.ServiceProvider.GetService<IDbContext>();
//                context.Migrate();
//            }
//            app.ConfigureErrorHandlingMiddleware();
//            app.UseCors("CrossDomainPolicy");
//            app.UseAuthentication();

//            app.UseSwagger();

//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("v1/swagger.json", "HR V1");
//                c.DocExpansion(DocExpansion.None);
//            });

//            app.UseStaticFiles();
//            app.UseRouting();
//            app.UseAuthorization();
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute("default", "{Controller=swagger}/{action=Index.html}");
//            });

//            app.UseMvc();

//        }

//        private void Registrar(IServiceCollection services, AssemblyHelper assemblyHelper)
//        {
//            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
//                .AddJsonFile("AppSettings.json", true, true)
//                .AddJsonFile($"AppSettings.{env.EnvironmentName}.json", true, true);
//            var connectionString = builder.Build().GetConnectionString("DefaultConnection");
//            var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
//            foreach (IRegistrar registrar in registrars)
//            {
//                registrar.Register(services, connectionString);
//            }

//            services.AddDbContext<HRContext>(op =>
//            {
//                op.UseSqlServer(connectionString);
//                //op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//            }, ServiceLifetime.Transient);
//            services.AddDbContext<KargoziniContext>(op => op.UseSqlServer(connectionString));
//        }


//        private static void AddControllers(AssemblyHelper assemblyHelper, IMvcBuilder mvcBuilder)
//        {
//            var controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeCommandBase)).Distinct();

//            foreach (var apiControllerAssembly in controllerAssemblies)
//            {
//                mvcBuilder.AddApplicationPart(apiControllerAssembly);
//            }

//            controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeQueryBase)).Distinct();
//            foreach (var apiControllerAssembly in controllerAssemblies)
//            {
//                mvcBuilder.AddApplicationPart(apiControllerAssembly);
//            }
//        }
//    }
//    public class ActiveUserFilter : IAsyncActionFilter
//    {
//        public async Task OnActionExecutionAsync(
//            ActionExecutingContext context,
//            ActionExecutionDelegate next)
//        {
//            // var userName = context.HttpContext.User.Identity.IsAuthenticated;
//            if (context.HttpContext.User.Identity.IsAuthenticated)
//            {

//                var current = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//                if (current == "")
//                {
//                    current = "Production";
//                }
//                var env = context.HttpContext.User.FindFirst("HRMS_env");
//                if (env != null)
//                {
//                    var envList = context.HttpContext.User.FindFirst("HRMS_env").Value.Split(",");
//                    if (envList.Contains(current))
//                    {
//                        await next();
//                    }
//                    else
//                    {
//                        context.Result = new UnauthorizedResult();
//                        return;
//                    }
//                }
//                else
//                {
//                    context.Result = new UnauthorizedResult();
//                    return;
//                }


//            }
//            else
//            {
//                await next();
//            }



//        }
//    }

//}

