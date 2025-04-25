using D2R.Repositories;
using System.Security.Cryptography;
using System.Text;
using D2R.Models;

namespace D2R.Services;

public class AuthService
{
    private readonly UserRepository _userRepository;

    public AuthService()
    {
        _userRepository = new UserRepository();
    }

    public object? Auth(User curruser)
    {
        var user = _userRepository.GetByUsername(curruser.Username);
        if (user == null || !Verify(curruser.Password, user.Password, user.Salt) || user.Username != curruser.Username)
        {
            return null;
        }
        return user;
    }

    private bool Verify(string Password, string HashedPassword, string Salt)
    {
        if (ComputeSHA256Hash(Password + Salt) == HashedPassword)
        {
            return true;
        }
        return false;
    }

    public string GenerateSaltBase64(int length)
    {
        byte[] saltBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public string ComputeSHA256Hash(string input)
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