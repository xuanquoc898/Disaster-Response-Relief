using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class DisasterTypeService
    {
        private readonly DisasterTypeRepository _repository;

        public DisasterTypeService()
        {
            _repository = new DisasterTypeRepository();
        }

        public List<DisasterType> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
