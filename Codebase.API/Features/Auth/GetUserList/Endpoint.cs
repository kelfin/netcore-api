using System;
using Codebase.Application.Interfaces;

namespace Codebase.API.Features.Auth.GetUserList;

public class Endpoint: EndpointWithoutRequest<Response>
{
    private IAuthService _authService;
    public Endpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("auth/get-user-list");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Response.Users = _authService.GetUserList();
        
        await SendAsync(Response);
    }
}
