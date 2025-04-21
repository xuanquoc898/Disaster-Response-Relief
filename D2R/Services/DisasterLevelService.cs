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

        public DisasterLevel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(DisasterLevel entity)
        {
            _repository.Add(entity);
        }

        public void Update(DisasterLevel entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
