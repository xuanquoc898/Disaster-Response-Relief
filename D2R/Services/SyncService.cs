using D2R.Models;

namespace D2R.Services
{
    public class SyncService
    {
        private readonly SyncLogService _syncLogService;
        private readonly SyncLogItemService _syncLogItemService;
        private readonly WarehouseStockService _stockService;

        public SyncService()
        {
            _syncLogService = new SyncLogService();
            _syncLogItemService = new SyncLogItemService();
            _stockService = new WarehouseStockService();
        }

        public void SyncToCentralWarehouse(int staffWarehouseId)
        {
            var stockList = _stockService.GetAll()
                .FindAll(ws => ws.WarehouseId == staffWarehouseId);

            if (stockList.Count == 0)
                return;

            var syncLog = new SyncLog
            {
                WarehouseId = staffWarehouseId,
                SyncDate = DateTime.Now,
                Status = "Success"
            };
            _syncLogService.Add(syncLog);
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
                _syncLogItemService.Add(logItem);
                AddOrUpdateCentral((int)item.ItemId, (int)item.Quantity);
            }

            foreach (var item in stockList)
            {
                _stockService.Delete(item.StockId);
            }
        }

        private void AddOrUpdateCentral(int itemId, int quantity)
        {
            var centralStock = _stockService.GetAll()
                .Find(ws => ws.ItemId == itemId && ws.WarehouseId == null);

            if (centralStock != null)
            {
                centralStock.Quantity += quantity;
                _stockService.Update(centralStock);
            }
            else
            {
                _stockService.Add(new WarehouseStock
                {
                    WarehouseId = null,
                    ItemId = itemId,
                    Quantity = quantity,
                    LastUpdated = DateTime.Now
                });
            }
        }
    }
}