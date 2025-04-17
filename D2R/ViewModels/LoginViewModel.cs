using D2R.Services;
using D2R.Models;
namespace D2R.ViewModels;

public class LoginViewModel
{
     private readonly AuthService _authService;
     private string _username = string.Empty;
     private string _password = string.Empty;
     private string _errorMessage = string.Empty;
     private bool _isLoggedIn = false;
     private bool _isLoginMode;

     public LoginViewModel(AuthService authService)
     {
          _authService = authService;
     }

     public bool Login(string username, string password)
     {
          if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
          {
               return false;
          }

          var user = _authService.Auth(username, password);
          if (user == null)
          {
               return false;
          }
          
          return true;
     }
}