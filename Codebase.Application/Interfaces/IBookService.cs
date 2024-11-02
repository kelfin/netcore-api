using System;
using Codebase.Application.ViewModels;

namespace Codebase.Application.Interfaces;

public interface IBookService
{
    BookViewModel CreateBook(BookViewModel data);
    BookViewModel UpdateBook(BookViewModel data);
    bool DeleteBook(int ID);
    BookViewModel GetBook(int ID);
    List<BookViewModel> GetBookList();

}
