using System;

namespace Codebase.API.Features.Auth.Status;

public class Response
{
    public string Email { set; get; }
    public string Username { set; get; }
    public bool IsAuthenticated {get; set;}
}
