using System;
using Codebase.Domain.Interfaces;
using Codebase.Domain.Models;
using Codebase.Infrastructure.Data.Context;

namespace Codebase.Infrastructure.Data.Repositories;

public class BookRepository : IBookRepository
{
    public ApplicationDBContext _context;
    public BookRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetBooks()
    {
        return _context.Books;
    }
}
