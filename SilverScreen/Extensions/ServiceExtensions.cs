using AspNetCoreRateLimit;
using Contracts.Base;
using Contracts.Logger;
using Entities.ConfigurationModels;
using Entities.Users;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Base;
using Repository.Context;
using Service.Contracts.Base;
using Services.Base;
using System.Text;

namespace SilverScreen.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(option =>
            {
               option.AddPolicy("CorsPolicy", policy =>
               policy.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("X-Pagination"));
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(option => { });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void AddCustomMediaType(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutPutFormatter = config.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();

                if (systemTextJsonOutPutFormatter != null)
                {
                    systemTextJsonOutPutFormatter.SupportedMediaTypes.Add("application/vnd.silverscrn.hateoas+json");
                }

                var xmlOutputFormatter = config.OutputFormatters.OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter != null)
                {
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.silverscrn.hateoas+xml");
                }
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services) =>
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching();

        public static void ConfigureHttpCacheHeader(this IServiceCollection services) =>
            services.AddHttpCacheHeaders(
                (exprationOpt) =>
                {
                    exprationOpt.MaxAge = 60;
                    exprationOpt.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
                },
                (validationOpt) =>
                {
                    validationOpt.MustRevalidate = true;
                }

                );

        public static void ConfigureRateLimitingOption(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 1 ,
                    Period = "1s"
                },
                new RateLimitRule
                {
                    Endpoint = "get:/api/categories",
                    Period = "1m",
                    Limit = 10 
                }
            };

            services.Configure<IpRateLimitOptions>(opt => { opt.GeneralRules = rateLimitRules; });      
            services.AddSingleton<IRateLimitCounterStore,MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore,MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy,AsyncKeyLockProcessingStrategy>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
    
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)=>         
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        

    }
}
