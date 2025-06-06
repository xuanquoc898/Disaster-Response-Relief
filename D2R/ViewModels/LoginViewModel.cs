using D2R.Commands;
using D2R.Helpers;
using D2R.Models;
using D2R.Services;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Input;
using D2R.Views.UserControls;
using MySqlConnector;

namespace D2R.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isLoggedIn;

    public event Action? LoginSucceeded;
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        _authService = new AuthService();
        LoginCommand = new RelayCommand(LoginAsync, CanExecuteLogin);
    }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set
        {
            _isLoggedIn = value;
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }

    private void LoginAsync(object? obj)
    {
        _ = Login(obj);
    }
    private async Task Login(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Username and/or password are required!";
            return;
        }

        User auth_user = new User();
        auth_user.Username = Username;
        auth_user.Password = Password;
        try
        {
            var user = await _authService.Auth(auth_user);
            if (user == null)
            {
                ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu!";
                return;
            }
            ErrorMessage = string.Empty;
            IsLoggedIn = true;
            LoginSession.CurrentUser = (User)user;
            LoginSucceeded?.Invoke();
        }
        catch (MySqlException e)
        {
            ErrorMessage = "Vui lòng kết nối mạng!";
            return;
        }
    }

    private bool CanExecuteLogin(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}