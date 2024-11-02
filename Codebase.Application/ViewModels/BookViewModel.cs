using System;

namespace Codebase.Application.ViewModels;

public class BookViewModel
{
    public int ID { set; get; }
    public string Title { set; get; }
    public string Sysnopsis { set; get; }
    public string Author { set; get; }
    public bool IsExist {set;get;}
}
