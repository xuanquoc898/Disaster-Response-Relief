using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class AreaService
    {
        private readonly AreaRepository _repository;

        public AreaService()
        {
            _repository = new AreaRepository();
        }

        public List<Area> GetAll()
        {
            return _repository.GetAll();
        }

        public Area GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Area entity)
        {
            _repository.Add(entity);
        }

        public void Update(Area entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
