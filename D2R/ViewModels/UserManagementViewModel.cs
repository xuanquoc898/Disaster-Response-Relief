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
    private List<string> _warehouses = new();
    private Warehouse? _selectedWarehouse = new();

    public IEnumerable<User> Users => _users;
    public IEnumerable<string> Warehouses => _warehouses;

    public UserManagementViewModel()
    {
        _userManagermentService = new UserManagermentService();
        _authService = new AuthService();
        LoadUsers();
    }

    public void LoadUsers()
    {
        _users = _userManagermentService.GetAllUser().ToList();
        _warehouses = _userManagermentService.GetAllWarehouse();
        // _areas = _userManagermentService.GetAllArea().ToList();
    }


    public bool NameWarehouseIsExist(string nameitem)
    {
        foreach (var warehouse in _warehouses)
        {
            if (warehouse == nameitem)
            {
                return true;
            }
        }
        return false;
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

    public void AddUser(string username, string password, string? role, string? warehouseName, Area area)
    {
        string salt = _authService.GenerateSaltBase64(32);
        var roleTmp = _userManagermentService.GetRoleByName(role);

        // TODO: Kiểm tra điều kiện (ngày 9/5)
        // CheckInputNullorEmpty(username);
        // CheckInputNullorEmpty(password);
        // CheckInputNullorEmpty(warehouseName);

        if (!NameWarehouseIsExist(warehouseName))
        {
            var warehouse = new Warehouse()
            {
                Name = warehouseName,
                Area = area,
                Type = "Local"
            };
            _userManagermentService.AddWarehouse(warehouse);
        }

        var user = new User()
        {
            Username = username,
            Salt = salt,
            Password = _authService.ComputeSHA256Hash(password + salt),
            RoleId = roleTmp.RoleId,
            WarehouseId = _userManagermentService.GetWarehouseByName(warehouseName)?.WarehouseId,
            AreaId = _userManagermentService.GetWarehouseByName(warehouseName)?.AreaId
        };
        _userManagermentService.Add(user);
        LoadUsers();
    }

    public void ClearSelection()
    {
        _selectedUser = null;
    }
}