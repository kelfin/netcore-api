using System.Security.Cryptography;
using Codebase.Application.Interfaces;
using Codebase.Application.ViewModels;
using Codebase.Domain.Interfaces;
using Codebase.Domain.Models;

namespace Codebase.Application.Services;

public class AuthService : IAuthService
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 10000;

    public IUserRepository _userRepository;
    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserListViewModel> GetUserList()
    {
        return _userRepository.GetUsers().Select(row => new UserListViewModel(){
            Email = row.Email,
            Username = row.Username
        }).ToList();
    }

    public LoginValidityViewModel Login(string email, string password)
    {
        var user = _userRepository.GetUser(email);
        if(user == null)
            return new LoginValidityViewModel()
            {
                Email = email,
                IsValid = false,
            };
        
        var isValid = VerifyPassword(password, user.Password);

        return new LoginValidityViewModel()
            {
                Email = email,
                IsValid = isValid,
            };
    }

    public RegisterValidityViewModel Register(RegisterViewModel data)
    {
        var isExist = _userRepository.GetUser(data.Email);

        if(isExist != null)
            return new RegisterValidityViewModel()
            {
                Email = data.Email,
                IsRegisterSucces = false,
                ValidationMessage = "Email already exist!"
            };

        _userRepository.CreateUser(new Domain.Models.User()
        {
            Email = data.Email,
            Username = data.Username,
            Password = HashPassword(data.Password)
        });

        return new RegisterValidityViewModel()
        {
            Email = data.Email,
            IsRegisterSucces = true
        };
    }

    private string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt); // Generate a new salt

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(KeySize);

            // Combine salt and hash as a single base64 string
            byte[] hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        // Extract salt and hash from the stored hash
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(KeySize);

            // Compare the generated hash with the stored hash
            for (int i = 0; i < KeySize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }
            return true;
        }
    }
}
