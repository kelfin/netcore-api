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

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
