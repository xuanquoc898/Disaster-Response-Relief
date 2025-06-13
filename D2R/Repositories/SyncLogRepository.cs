using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class SyncLogRepository
    {
        private readonly DisasterReliefContext _context;

        public SyncLogRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<SyncLog> GetAll()
        {
            return _context.SyncLogs
                .Include(s => s.Warehouse)
                .OrderByDescending(s => s.SyncDate)
                .ToList();
        }

        public void Add(SyncLog entity)
        {
            _context.SyncLogs.Add(entity);
            _context.SaveChanges();
        }
        public List<SyncLog> GetHistoryByWarehouse(int warehouseId)
        {
            return _context.SyncLogs
                .Include(s => s.Warehouse)
                .Where(log => log.WarehouseId == warehouseId)
                .OrderByDescending(log => log.SyncDate)
                .ToList();
        }
    }
}
