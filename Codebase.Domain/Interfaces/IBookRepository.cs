using System;
using Codebase.Domain.Models;

namespace Codebase.Domain.Interfaces;

public interface IBookRepository
{
     IEnumerable<Book> GetBooks();
}
