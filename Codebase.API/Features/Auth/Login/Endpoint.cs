using System;
using FastEndpoints.Security;

namespace Codebase.API.Features.Auth.Login;

public class UserLoginEndpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        if (await CredentialsAreValid(req.Username, req.Password, ct))
        {
            var jwtToken = JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = AppSetting.SigningKey;
                    o.ExpireAt = DateTime.UtcNow.AddMinutes(AppSetting.ExpirationMinutes);
                    o.User.Roles.Add("Manager", "Auditor");
                    o.User.Claims.Add(("UserName", req.Username));
                    o.User["UserId"] = "001"; //indexer based claim setting
                });

            await SendAsync(
                new
                {
                    req.Username,
                    Token = jwtToken
                });
        }
        else
            ThrowError("The supplied credentials are invalid!");
    }

    private async Task<bool> CredentialsAreValid(string username, string password, CancellationToken ct){
        return true;
    }
}