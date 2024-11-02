using System;
using Codebase.Domain.Models;

namespace Codebase.Domain.Interfaces;

public interface IBookRepository
{
     IEnumerable<Book> GetBooks();
     Book GetBook(int ID);
     Book CreateBook(Book data);
     Book UpdateBook(Book data);
     bool DeleteBook(int ID);
     bool IsExist(string Title);
}
