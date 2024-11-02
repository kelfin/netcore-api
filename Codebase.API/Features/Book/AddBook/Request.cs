using System;

namespace Codebase.API.Features.Book.AddBook;

public class Request
{
    public string Title { set; get; }
    public string Sysnopsis { set; get; }
    public string Author { set; get; }
}
