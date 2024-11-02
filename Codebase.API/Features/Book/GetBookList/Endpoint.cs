using System.Net;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Codebase.API.Features.Book.GetBookList;

public class Endpoint: Endpoint<Request, Response>
{
    public override void Configure()
    {
        //AllowAnonymous();
        Get("get-book-list");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        //var Model = new Model();
        
        await SendAsync(Response);
    }
}