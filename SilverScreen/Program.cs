using AspNetCoreRateLimit;
using Contracts.Base;
using Contracts.Logger;
using Contracts.Movies;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Presentation.ActionFilters;
using Services.DataShaping;
using Shared.DataTransferObjects.Movies;
using SilverScreen.Extensions;
using SilverScreen.Utility;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidationMediaTypeAttribute>();
builder.Services.AddScoped<IDataShaper<MovieDto>, DataShaper<MovieDto>>();
builder.Services.AddScoped<IMovieLinks,MovieLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeader();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOption();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("300SecondsDuration", new CacheProfile { Duration = 300 });

}).AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddCustomMediaType();

var app = builder.Build();

// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);


if(app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});
app.UseIpRateLimiting();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
