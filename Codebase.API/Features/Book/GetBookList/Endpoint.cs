using System.Net;
using Codebase.Application.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Codebase.API.Features.Book.GetBookList;

public class Endpoint: EndpointWithoutRequest<Response>
{
    private IBookService _bookService;
    public Endpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Get("book/get-list");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Response.Books = _bookService.GetBookList();
        await SendAsync(Response);
    }
}