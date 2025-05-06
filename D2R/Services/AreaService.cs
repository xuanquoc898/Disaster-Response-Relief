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
    }
}
