using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class WarehouseStockService
    {
        private readonly WarehouseStockRepository _repository;

        public WarehouseStockService()
        {
            _repository = new WarehouseStockRepository();
        }

        public List<WarehouseStock> GetAll()
        {
            return _repository.GetAll();
        }

        public WarehouseStock GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(WarehouseStock entity)
        {
            _repository.Add(entity);
        }

        public void Update(WarehouseStock entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void AddOrUpdateStock(int? warehouseId, int itemId, int quantity)
        {
            var existing = GetAll()
                .FirstOrDefault(s => s.WarehouseId == warehouseId && s.ItemId == itemId);

            if (existing != null)
            {
                existing.Quantity = (existing.Quantity ?? 0) + quantity;
                Update(existing);
            }
            else
            {
                var newStock = new WarehouseStock
                {
                    WarehouseId = warehouseId,
                    ItemId = itemId,
                    Quantity = quantity,
                    LastUpdated = DateTime.Now
                };
                Add(newStock);
            }
        }

    }
}
