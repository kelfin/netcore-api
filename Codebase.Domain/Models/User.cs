using System;
using System.ComponentModel.DataAnnotations;

namespace Codebase.Domain.Models;

public class User
{
    [Key]
    public string Email { set; get; }
    public string Username { set; get; }
    public string Password { set; get; }
}
