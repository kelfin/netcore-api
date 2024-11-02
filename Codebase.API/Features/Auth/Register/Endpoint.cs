using System;
using Codebase.Application.Interfaces;

namespace Codebase.API.Features.Auth.Register;

public class Endpoint: Endpoint<Request, Response>
{
    private IAuthService _authService;
    public Endpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("auth/register");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var register = _authService.Register(new Application.ViewModels.RegisterViewModel()
        {
            Email = req.Email,
            Username = req.Username,
            Password = req.Password
        });

        Response.Email = register.Email;
        Response.IsSuccess = register.IsRegisterSucces;
        Response.Message = register.ValidationMessage;
        
        await SendAsync(Response);
    }
}