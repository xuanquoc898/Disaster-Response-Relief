using D2R.Repositories;
using D2R.ViewModels;

namespace D2R.Services
{
    public class WarehouseStockService
    {
        private readonly WarehouseStockRepository _repository;
        private readonly SyncLogRepository _syncRepo;
        private readonly DistributionLogRepository _distRepo;
        public WarehouseStockService()
        {
            _repository = new WarehouseStockRepository();
            _syncRepo = new SyncLogRepository();
            _distRepo = new DistributionLogRepository();
        }

        public int GetQuantity(int itemId)
        {
            // var stock = _repository.GetAll()
            //     .FirstOrDefault(s => s.ItemId == itemId && s.WarehouseId == 1);
            var stock = _repository.GetByWarehouseIdItemId(1, itemId);
            return stock?.Quantity ?? 0;
        }
        
        // giam stock trong kho trung tam
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

        public WarehouseChartStats GetDailyStockStats(int year, int month)
        {
            return _repository.GetDailyStockStats(year, month);
        }
    }
}