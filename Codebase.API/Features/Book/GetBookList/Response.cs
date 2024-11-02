using System;
using Codebase.Application.ViewModels;

namespace Codebase.API.Features.Book.GetBookList;

public class Response
{
    public List<BookViewModel> Books {set;get;}
}