using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class SyncOperationService
    {
        private readonly SyncLogRepository _synclogRepository;
        private readonly WarehouseStockRepository _stockRepository;
        private readonly SyncLogItemRepository _synclogitemRepository;
        public SyncOperationService()
        {
        }
        public void SyncToCentralWarehouse(int warehouseId)
        {
            var stockList = _stockRepository.GetStockById(warehouseId);

            if (stockList.Count == 0)
                return;

            var syncLog = new SyncLog
            {
                WarehouseId = warehouseId,
                SyncDate = DateTime.Now,
                Status = "Success"
            };

            _synclogRepository.Add(syncLog);
            int syncId = syncLog.SyncId;

            foreach (var item in stockList)
            {
                var logItem = new SyncLogItem
                {
                    SyncId = syncId,
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    Unit = ""
                };
                _synclogitemRepository.Add(logItem);

                AddOrUpdateCentral((int)item.ItemId, (int)item.Quantity);
            }

            foreach (var item in stockList)
            {
                _stockRepository.Delete(item.StockId);
            }
        }

        private void AddOrUpdateCentral(int itemId, int quantity)
        {
            var centralStock = _stockRepository.GetCentralStockByItemId(itemId);

            if (centralStock != null)
            {
                centralStock.Quantity += quantity;
                _stockRepository.Update(centralStock);
            }
            else
            {
                _stockRepository.Add(new WarehouseStock
                {
                    WarehouseId = null,
                    ItemId = itemId,
                    Quantity = quantity,
                    LastUpdated = DateTime.Now
                });
            }
        }

        public List<SyncLog> GetHistoryByWarehouse(int warehouseId)
        {
            return _synclogRepository.GetHistoryByWarehouse(warehouseId);
        }
    }
}
