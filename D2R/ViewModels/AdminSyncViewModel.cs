using D2R.Models;
using D2R.Services;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.ViewModels
{
    public class AdminSyncViewModel
    {
        private readonly SyncOperationService _syncService;
        private readonly WarehouseRepository _warehouseRepo;

        public AdminSyncViewModel()
        {
            _syncService = new SyncOperationService();
            _warehouseRepo = new WarehouseRepository();
        }

        public List<SyncLog> GetLogs(int? warehouseId)
        {
            var logs = warehouseId.HasValue
                ? _syncService.GetHistoryByWarehouse(warehouseId.Value)
                : _syncService.GetAllSyncLogs();

            return logs
                .Where(log => log.WarehouseId != 1) 
                .ToList();
        }
        public List<Warehouse> GetAllWarehouses()
        {
            return _warehouseRepo.GetAllWarehouses()
                .Where(w => w.WarehouseId != 1)
                .ToList();
        }

    }
}
