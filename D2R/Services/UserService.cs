using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(User entity)
        {
            _repository.Add(entity);
        }

        public void Update(User entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<User> GetStaffsByAreaId(int areaId)
        {
            return _repository.GetStaffsByAreaId(areaId);
        }
        public List<User> GetAdmins()
        {
            return _repository.GetAdmins(); 
        }
    }
}
