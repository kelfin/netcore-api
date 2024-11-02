using System;
using Codebase.Application.Interfaces;
using Codebase.Application.ViewModels;
using Codebase.Domain.Interfaces;

namespace Codebase.Application.Services;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public BookViewModel CreateBook(BookViewModel data)
    {
        data.IsExist = _bookRepository.IsExist(data.Title);

        if(data.IsExist)
            return data;

        _bookRepository.CreateBook(new Domain.Models.Book()
        {
            Title = data.Title,
            Author = data.Author,
            Sysnopsis = data.Sysnopsis
        });

        return data;
    }

    public bool DeleteBook(int ID)
    {
        _bookRepository.DeleteBook(ID);

        return true;
    }

    public BookViewModel GetBook(int ID)
    {
        var book = _bookRepository.GetBook(ID);
        return new BookViewModel()
        {
            ID = book.ID,
            Title = book.Title,
            Author = book.Author,
            Sysnopsis = book.Sysnopsis
        };
    }

    public List<BookViewModel> GetBookList()
    {
        return _bookRepository.GetBooks().Select(row => new BookViewModel()
        {
            ID = row.ID,
            Title = row.Title,
            Author = row.Author,
            Sysnopsis = row.Sysnopsis
        }).ToList();
    }

    public BookViewModel UpdateBook(BookViewModel data)
    {
        _bookRepository.UpdateBook(new Domain.Models.Book()
        {
            ID = data.ID,
            Title = data.Title,
            Author = data.Author,
            Sysnopsis = data.Sysnopsis
        });

        return new BookViewModel()
        {
            ID = data.ID,
            Title = data.Title,
            Author = data.Author,
            Sysnopsis = data.Sysnopsis
        };
    }
}
