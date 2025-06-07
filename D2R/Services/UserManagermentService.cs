using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class UserManagermentService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly WarehouseRepository _warehouseRepository;
        public UserManagermentService()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _warehouseRepository = new WarehouseRepository();
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
        public void Add(User? entity)
        {
            _userRepository.Add(entity);
        }

        public void Delete(string username)
        {
            _userRepository.Delete(username);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }

        public Role GetRoleByName(string? roleName)
        {
            return _roleRepository.GetByName(roleName);
        }

        public Warehouse? GetWarehouseByName(string? warehouseName)
        {
            return _warehouseRepository.GetWarehouseByName(warehouseName);
        }

        public void AddWarehouse(Warehouse entity)
        {
            _warehouseRepository.AddWarehouse(entity);
        }

        public Role GetById(int roleId)
        {
            return _roleRepository.GetById(roleId);
        }
        public List<string> GetAllWarehouse()
        {
            return _warehouseRepository.GetAll();
        }
    }
}
