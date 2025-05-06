using D2R.Helpers;
using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels;

public class UserManagementViewModel
{
    private UserService _userService;
    private AuthService _authService;
    private RoleService _roleService;
    private WarehouseService _warehouseService;
    private AreaService _areaService;

    private List<User> _users;
    private User _selectedUser;
    private List<Warehouse> _warehouses;
    private Warehouse _selectedWarehouse;
    private List<Area> _areas;
    private Area _selectedArea;

    public IEnumerable<User> Users => _users; // Interface chỉ đọc
    public IEnumerable<Warehouse> Warehouses => _warehouses;
    public IEnumerable<Area> Areas => _areas;
    public User SelectedUser => _selectedUser;
    public Warehouse SelectedWarehouse => _selectedWarehouse;
    public Area SelectedArea => _selectedArea;

    public UserManagementViewModel()
    {
        LoadUsers();
    }

    public void LoadUsers()
    {
        _userService = new UserService();
        _roleService = new RoleService();
        _authService = new AuthService();
        _warehouseService = new WarehouseService();
        _areaService = new AreaService();
        _users = _userService.GetAll().ToList();
        _warehouses = _warehouseService.GetAll().ToList();
        _areas = _areaService.GetAll().ToList();
    }

    public void SelectUser(User user)
    {
        _selectedUser = user;
    }

    public bool CanResetPassword()
    {
        return _selectedUser != null && _roleService.GetById(LoginSession.CurrentUser.RoleId).RoleName == "Admin";
    }

    public string ResetPassword()
    {
        if (!CanResetPassword())
            return null;

        _selectedUser.Salt = _authService.GenerateSaltBase64(32);
        var newPass = _selectedUser.Username + "A@" + _selectedUser.Salt;
        _selectedUser.Password = _authService.ComputeSHA256Hash(newPass);
        _userService.Update(_selectedUser);
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

        _userService.Delete(_selectedUser.Username);
        LoadUsers();
        return true;
    }

    public void AddUser(string username, string password, string role,
                        string warehouseName, object Location)
    {
        string salt = _authService.GenerateSaltBase64(32);
        var role_tmp = new Role();
        role_tmp = _roleService.GetByName(role);
        var user = new User()
        {
            Username = username,
            Salt = salt,
            Password = _authService.ComputeSHA256Hash(password + salt),
            RoleId = role_tmp.RoleId

        };
        _userService.Add(user);
        LoadUsers();
    }

    public void ClearSelection()
    {
        _selectedUser = null;
    }
}