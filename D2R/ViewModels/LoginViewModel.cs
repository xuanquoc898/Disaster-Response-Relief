using System.ComponentModel;
using System.Windows.Input;
using D2R.Services;
using D2R.Commands;
using D2R.Helpers;
using D2R.Models;

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
        LoginCommand = new RelayCommand(Login, CanExecuteLogin);
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

    private void Login(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Username and/or password are required!";
            return ;
        }

        User auth_user = new User();
        auth_user.Username = Username;
        auth_user.Password = Password;
        var user = _authService.Auth(auth_user);
        if (user == null)
        {
            ErrorMessage = "Invalid username or password!";
            return ;
        }

        ErrorMessage = string.Empty;
        IsLoggedIn = true;
        LoginSession.CurrentUser = (User)user;
        LoginSucceeded?.Invoke();

    }

    private bool CanExecuteLogin(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}