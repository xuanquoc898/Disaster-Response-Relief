using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class DisasterLevelService
    {
        private readonly DisasterLevelRepository _repository;

        public DisasterLevelService()
        {
            _repository = new DisasterLevelRepository();
        }

        public List<DisasterLevel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
