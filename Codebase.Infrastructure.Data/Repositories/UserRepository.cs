using System;
using Codebase.Domain.Interfaces;
using Codebase.Domain.Models;
using Codebase.Infrastructure.Data.Context;

namespace Codebase.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    public ApplicationDBContext _context;
    public UserRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public User CreateUser(User data)
    {
        _context.Users.Add(data);
        return data;
    }

    public User GetUser(string email)
    {
        return _context.Users.FirstOrDefault(user => user.Email == email);
    }

    public IEnumerable<User> GetUsers()
    {
        return _context.Users;
    }
}
