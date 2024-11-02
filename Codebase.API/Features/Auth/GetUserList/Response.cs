using System;
using Codebase.Application.ViewModels;

namespace Codebase.API.Features.Auth.GetUserList;

public class Response
{
    public List<UserListViewModel> Users {set;get;}
}
