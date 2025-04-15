using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

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

        public Role GetById(int id)
        {
            return _repository.GetById(id);
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
