using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class SyncViewModel
    {
        private readonly int _warehouseId;
        private readonly SyncOperationService _syncOpService;

        public SyncViewModel(int warehouseId)
        {
            _warehouseId = warehouseId;
            _syncOpService = new SyncOperationService();
        }

        public void Sync()
        {
            _syncOpService.SyncToCentral(_warehouseId);
        }

        public List<SyncLog> GetSyncHistory()
        {
            return _syncOpService.GetHistoryByWarehouse(_warehouseId);
        }
    }
}