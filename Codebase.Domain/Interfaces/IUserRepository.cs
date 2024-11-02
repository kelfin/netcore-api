using System;
using Codebase.Domain.Models;

namespace Codebase.Domain.Interfaces;

public interface IUserRepository
{
    User GetUser(string email);
    User CreateUser(User data);
    IEnumerable<User> GetUsers();
}
