global using FastEndpoints;
global using FastEndpoints.Swagger;
global using FastEndpoints.Security;
using Codebase.API;

var builder = WebApplication.CreateBuilder(args);

AppSetting.SigningKey = builder.Configuration["JwtSettings:SecretKey"];
AppSetting.ExpirationMinutes = int.Parse(builder.Configuration["JwtSettings:ExpirationMinutes"]);

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

var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
