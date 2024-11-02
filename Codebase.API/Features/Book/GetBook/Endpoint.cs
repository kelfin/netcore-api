using System;
using Codebase.Application.Interfaces;

namespace Codebase.API.Features.Book.GetBook;

public class Endpoint: Endpoint<Request, Response>
{
    private IBookService _bookService;
    public Endpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Get("book/get");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Response.Book = _bookService.GetBook(req.ID);
        
        await SendAsync(Response);
    }
}