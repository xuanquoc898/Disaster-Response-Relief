using D2R.Models;
using D2R.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace D2R.Services;

public class AuthService
{
    private readonly UserRepository _userRepository = new();

    public async Task<object?> Auth(User curruser)
    {
        var user = await _userRepository.GetByUsername(curruser.Username); // lay user co username la curruser.username
        if (user == null || !Verify(curruser.Password, user.Password, user.Salt) || user.Username != curruser.Username) // kiem tra trung khop mat khau va username
        {
            return null;
        }
        return user;
    }

    private bool Verify(string Password, string HashedPassword, string Salt)
    {
        if (ComputeSHA256Hash(Password + Salt) == HashedPassword) // kiem tra mat khau nguoi dung nhap vao + voi salt sau khi băm co giong mk đc luu trong csdl khong
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
            byte[] inputBytes = Encoding.UTF8.GetBytes(input); // chuyen thanh chuoi byte
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