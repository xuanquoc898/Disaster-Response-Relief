using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class WarehouseItemService
    {
        private readonly WarehouseItemRepository _repository;

        public WarehouseItemService()
        {
            _repository = new WarehouseItemRepository();
        }

        public List<WarehouseItem> GetAll()
        {
            return _repository.GetAll();
        }

        public WarehouseItem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(WarehouseItem entity)
        {
            _repository.Add(entity);
        }

        public void Update(WarehouseItem entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
