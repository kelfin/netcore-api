using System;
using System.ComponentModel.DataAnnotations;

namespace Codebase.Domain.Models;

public class Book
{
    [Key]
    public int ID { set; get; }
    public string Title { set; get; }
    public string Sysnopsis { set; get; }
    public string Author { set; get; }

}
