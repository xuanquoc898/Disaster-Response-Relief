using D2R.Helpers;
using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels;

public class UserManagementViewModel
{
    private readonly UserManagermentService _userManagermentService;
    private readonly AuthService _authService;

    private List<User> _users = new();
    private User _selectedUser = new();
    private List<Warehouse> _warehouses = new();
    private Warehouse? _selectedWarehouse = new();
    private List<Area> _areas = new();
    private Area? _selectedArea = new();

    public IEnumerable<User> Users => _users; // Interface chỉ đọc
    public IEnumerable<Warehouse> Warehouses => _warehouses;
    public IEnumerable<Area> Areas => _areas;

    public UserManagementViewModel()
    {
        _userManagermentService = new UserManagermentService();
        _authService = new AuthService();
        LoadUsers();
    }

    public void LoadUsers()
    {
        _users = _userManagermentService.GetAllUser().ToList();
        _warehouses = _userManagermentService.GetAllWarehouse().ToList();
        _areas = _userManagermentService.GetAllArea().ToList();
    }

    public void SelectUser(User user)
    {
        _selectedUser = user;
    }

    public bool CanResetPassword()
    {
        return _selectedUser != null && _userManagermentService.GetById(LoginSession.CurrentUser.RoleId).RoleName == "Admin";
    }

    public string? ResetPassword()
    {
        if (!CanResetPassword())
            return null;

        _selectedUser.Salt = _authService.GenerateSaltBase64(32);
        var newPass = _selectedUser.Username + "A@" + _selectedUser.Salt;
        _selectedUser.Password = _authService.ComputeSHA256Hash(newPass);
        _userManagermentService.Update(_selectedUser);
        return newPass;
    }

    public bool CanDeleteUser()
    {
        return _selectedUser != null;
    }

    public bool DeleteUser()
    {
        if (!CanDeleteUser())
            return false;

        _userManagermentService.Delete(_selectedUser.Username);
        LoadUsers();
        return true;
    }

    public void AddUser(string username, string password, string role, string warehouseName)
    {
        string salt = _authService.GenerateSaltBase64(32);
        var role_tmp = _userManagermentService.GetByName(role);
        var user = new User()
        {
            Username = username,
            Salt = salt,
            Password = _authService.ComputeSHA256Hash(password + salt),
            RoleId = role_tmp.RoleId

        };
        _userManagermentService.Add(user);
        LoadUsers();
    }

    public void ClearSelection()
    {
        _selectedUser = null;
    }
}