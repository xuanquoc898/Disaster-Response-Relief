using D2R.Helpers;
using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels;

public class UserManagementViewModel
    {
        // private ObservableCollection<User> _users;
        private List<User> _users;
        private User _selectedUser;
        private UserService _userService;
        private AuthService _authService;
        private RoleService _roleService;
        public IEnumerable<User> Users => _users; // Interface chỉ đọc
        public User SelectedUser => _selectedUser;

        public UserManagementViewModel()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            _userService = new UserService();
            _roleService = new RoleService();
            _authService = new AuthService();
            _users = _userService.GetAll().ToList();
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

        public void AddUser(string username, string password, string role, string warehouseName, string warehouseLocation)
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