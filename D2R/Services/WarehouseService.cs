using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

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

        public Warehouse GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Warehouse entity)
        {
            _repository.Add(entity);
        }

        public void Update(Warehouse entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
