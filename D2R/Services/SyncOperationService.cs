using D2R.Models;

namespace D2R.Services
{
    public class SyncOperationService
    {
        private readonly SyncService _syncService;
        private readonly SyncLogService _logService;

        public SyncOperationService()
        {
            _syncService = new SyncService();
            _logService = new SyncLogService();
        }

        public void SyncToCentral(int warehouseId)
        {
            _syncService.SyncToCentralWarehouse(warehouseId);
        }

        public List<SyncLog> GetHistoryByWarehouse(int warehouseId)
        {
            return _logService.GetAll()
                .Where(log => log.WarehouseId == warehouseId)
                .OrderByDescending(log => log.SyncDate)
                .ToList();
        }
    }
}
