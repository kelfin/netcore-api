using System;
using Codebase.Application.ViewModels;

namespace Codebase.Application.Interfaces;

public interface IAuthService
{
    public LoginValidityViewModel Login(string email, string password);
    public RegisterValidityViewModel Register(RegisterViewModel data);
    public List<UserListViewModel> GetUserList();
}
