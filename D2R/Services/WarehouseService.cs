using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class WarehouseService
    {
        private readonly WarehouseRepository _repository;

        public WarehouseService()
        {
            _repository = new WarehouseRepository();
        }
        public List<Warehouse> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
