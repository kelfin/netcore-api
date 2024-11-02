using System;

namespace Codebase.API.Features.Book.UpdateBook;

public class Request
{
    public int ID {set;get;}
    public string Title { set; get; }
    public string Sysnopsis { set; get; }
    public string Author { set; get; }
}
