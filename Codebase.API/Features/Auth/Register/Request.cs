using System;

namespace Codebase.API.Features.Auth.Register;

public class Request
{
    public string Email { set; get; }
    public string Username { set; get; }
    public string Password { set; get; }
}
