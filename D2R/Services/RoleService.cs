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

        public List<Role> GetAll()
        {
            return _repository.GetAll();
        }

        public Role GetByName(string roleName)
        {
            return _repository.GetByName(roleName);
        }

        public Role GetById(int roleId)
        {
            return _repository.GetById(roleId);
        }

        public void Add(Role entity)
        {
            _repository.Add(entity);
        }

        public void Update(Role entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
