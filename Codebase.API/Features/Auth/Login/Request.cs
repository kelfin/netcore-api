using System;

namespace Codebase.API.Features.Auth.Login;

public class Request
{
    public string Email { set; get; }
    public string Password { set; get; }
}
