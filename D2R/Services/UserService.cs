using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class UserService
    {
        private readonly UserRepository _repository = new();

        public List<User?> GetStaffsByAreaId(int areaId)
        {
            return _repository.GetStaffsByAreaId(areaId);
        }
        public List<User?> GetAdmins()
        {
            return _repository.GetAdmins();
        }
    }
}
