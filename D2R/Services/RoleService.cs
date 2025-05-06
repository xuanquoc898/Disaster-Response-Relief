using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class RoleService
    {
        private readonly RoleRepository _repository;

        public RoleService()
        {
            _repository = new RoleRepository();
        }
        public Role GetByName(string roleName)
        {
            return _repository.GetByName(roleName);
        }

        public Role GetById(int roleId)
        {
            return _repository.GetById(roleId);
        }
    }
}
