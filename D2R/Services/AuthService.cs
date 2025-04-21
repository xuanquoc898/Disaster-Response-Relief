using System;
using System.Text;
using System.Security.Cryptography;
using D2R.Models;
using D2R.Repositories;

namespace D2R.Services;

public class AuthService
{
    private readonly UserRepository _userRepository;

    public AuthService()
    {
        _userRepository = new UserRepository();
    }

    public object? Auth(string username, string password)
    {
        var user = _userRepository.GetByUsername(username);
        if (user == null || !Verify(password, user.Password, user.Salt))
        {
            return null;
        }
        return user;
    }

    private bool Verify(string Password, string HashedPassword, string Salt)
    {
        if (ComputeSHA256Hash(Password+Salt) == HashedPassword)
        {
            return true;
        }
        return false;
    }
    
    static string GenerateSaltBase64(int length)
    {
        byte[] saltBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    static string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }   
}