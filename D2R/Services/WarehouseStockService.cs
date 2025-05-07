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
    }
}