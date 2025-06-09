using D2R.Commands;
using D2R.Helpers;
using D2R.Models;
using D2R.Services;
using MySqlConnector;
using System.ComponentModel;
using System.Windows.Input;

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

    private void LoginAsync(object? obj)
    {
        _ = Login();
        // Login()
    }
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Username and/or password are required!";
            return;
        }

        User auth_user = new User() {Username = Username, Password = Password};
        try
        {
            var user = await Task.Run(() => _authService.Auth(auth_user)); // Tạo luồng mới để thực thi xác thực tài khoản và đợi => trả về đối tượng đc xác thực
            if (user == null) // nếu thất bại
            {
                ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu!";
                return;
            }
            // Nếu xác thực thành công (có đối tượng trong csdl)
            ErrorMessage = string.Empty;
            LoginSession.CurrentUser = (User)user;
            LoginSucceeded?.Invoke(); // => gọi OnLoginSucceeded trong MainWindowViewModel để thay đổi View hiện tại là LoginView thành MenuView
        }
        catch (MySqlException)
        {
            ErrorMessage = "Vui lòng kết nối mạng!";
            return;
        }
    }

    private bool CanExecuteLogin(object? parameter) // kiểm tra điều kiện xem LoginButton có được phép click
    {
        return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        // return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}