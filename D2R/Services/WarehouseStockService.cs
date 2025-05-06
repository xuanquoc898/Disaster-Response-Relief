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
            var existing = _repository.GetAll()
                .FirstOrDefault(s => s.WarehouseId == warehouseId && s.ItemId == itemId);

            if (existing != null)
            {
                existing.Quantity = (existing.Quantity ?? 0) + quantity;
                existing.LastUpdated = DateTime.Now;
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

        public int GetQuantity(int itemId)
        {
            var stock = _repository.GetAll()
                .FirstOrDefault(s => s.ItemId == itemId && s.WarehouseId == 1);

            return stock?.Quantity ?? 0;
        }

        public void Decrease(int itemId, int quantity)
        {
            var stock = _repository.GetAll()
                .FirstOrDefault(s => s.ItemId == itemId && s.WarehouseId == 1);

            if (stock != null)
            {
                stock.Quantity -= quantity;
                _repository.Update(stock);
            }
        }
        public void SyncWarehouseFromDistribution(int campaignId, int warehouseId)
        {
            _repository.SyncWarehouseFromDistribution(campaignId, warehouseId);
        }
    }
}