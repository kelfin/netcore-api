using System;
using System.ComponentModel.DataAnnotations;

namespace Codebase.Domain.Models;

public class User
{
    public int ID { set; get; }
    public string Username { set; get; }
    public string Email { set; get; }
    public string Password { set; get; }
}
