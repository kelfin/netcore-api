using System;
using Codebase.Application.Interfaces;

namespace Codebase.API.Features.Book.UpdateBook;

public class Endpoint: Endpoint<Request, Response>
{
    private IBookService _bookService;
    public Endpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Post("book/update");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Response.Book = _bookService.UpdateBook(new Application.ViewModels.BookViewModel()
        {
            ID = req.ID,
            Title = req.Title,
            Author = req.Author,
            Sysnopsis = req.Sysnopsis
        });
        
        await SendAsync(Response);
    }
}