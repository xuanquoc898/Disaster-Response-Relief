using D2R.Models;
using D2R.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R.Services
{
    public class UserManagermentService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly AreaRepository _areaRepository;
        public UserManagermentService()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _warehouseRepository = new WarehouseRepository();
            _areaRepository = new AreaRepository();
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
        public void Add(User entity)
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

        public Role GetByName(string roleName)
        {
            return _roleRepository.GetByName(roleName);
        }

        public Role GetById(int roleId)
        {
            return _roleRepository.GetById(roleId);
        }
        public List<Warehouse> GetAllWarehouse()
        {
            return _warehouseRepository.GetAll();
        }
        public List<Area> GetAllArea()
        {
            return _areaRepository.GetAll();
        }
    }
}
