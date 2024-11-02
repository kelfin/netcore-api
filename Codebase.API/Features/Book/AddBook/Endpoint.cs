using System;
using Codebase.Application.Interfaces;

namespace Codebase.API.Features.Book.AddBook;

public class Endpoint: Endpoint<Request, Response>
{
    private IBookService _bookService;
    public Endpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Post("book/add");
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var book = _bookService.CreateBook(new Application.ViewModels.BookViewModel()
        {
            Title = req.Title,
            Author = req.Author,
            Sysnopsis = req.Sysnopsis
        });

        if(book.IsExist)
            ThrowError("Book already exist");

        Response.Book = book;
        
        await SendAsync(Response);
    }
}