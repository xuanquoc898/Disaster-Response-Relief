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
            _synclogRepository = new SyncLogRepository();
            _stockRepository = new WarehouseStockRepository();
            _synclogitemRepository = new SyncLogItemRepository();
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
                };
                _synclogitemRepository.Add(logItem);

                AddOrUpdateCentral((int)item.ItemId, (int)item.Quantity);

            }

            foreach (var item in stockList)
            {
                _stockRepository.Delete(item.StockId);
            }
        }
        // quyết định là add hay update
        private void AddOrUpdateCentral(int itemId, int quantity)
        {
            var centralStock = _stockRepository.GetCentralStockByItemId(itemId); // lấy tồn kho kho trun tâm thông qua ItemId dc truyen vao
            
            if (centralStock != null)
            {
                centralStock.Quantity += quantity; //tang quantity
                _stockRepository.Update(centralStock);
            }
            else
            {
                //neu chua ton tai vat pham thi tao mot vat pham moi va gan quantity
                _stockRepository.Add(new WarehouseStock
                {
                    WarehouseId = 1,
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
        
        // dong  bo nguoc tu central ve local, data đc lấy tu distributionlog
        public void SyncWarehouseFromDistribution(int campaignId, int warehouseId)
        {
            var distributions = _synclogitemRepository.GetDistributionsByCampaign(campaignId);

            foreach (var dist in distributions)
            {
                var existingStock = _synclogitemRepository.GetWarehouseStock(warehouseId, dist.ItemId);

                if (existingStock != null)
                {
                    existingStock.Quantity += dist.Quantity ?? 0;
                }
                else
                {
                    _synclogitemRepository.AddWarehouseStock(new WarehouseStock
                    {
                        WarehouseId = warehouseId,
                        ItemId = dist.ItemId,
                        Quantity = dist.Quantity ?? 0,
                        LastUpdated = DateTime.Now
                    });
                }
            }
            _synclogitemRepository.SaveChanges();
        }
        
        // lay all synclog tu db
        public List<SyncLog> GetAllSyncLogs()
        {
            return _synclogRepository.GetAll()
                .OrderByDescending(log => log.SyncDate)
                .ToList();
        }

    }
}
