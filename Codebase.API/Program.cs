global using FastEndpoints;
global using FastEndpoints.Swagger;
global using FastEndpoints.Security;
using Codebase.API;
using Codebase.Infrastructure.IoC;
using Codebase.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

AppSetting.SigningKey = builder.Configuration["JwtSettings:SecretKey"];
AppSetting.ExpirationMinutes = int.Parse(builder.Configuration["JwtSettings:ExpirationMinutes"]);

builder.Services.AddDbContext<ApplicationDBContext>();
builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = AppSetting.SigningKey);
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
