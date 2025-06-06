using D2R.Models;

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
            return _context.SyncLogs.ToList();
        }

        public void Add(SyncLog entity)
        {
            _context.SyncLogs.Add(entity);
            _context.SaveChanges();
        }
        public List<SyncLog> GetHistoryByWarehouse(int warehouseId)
        {
            return _context.SyncLogs
                .Where(log => log.WarehouseId == warehouseId)
                .OrderByDescending(log => log.SyncDate)
                .ToList();
        }
        public int GetTotalInboundUpToDate(DateTime date)
        {
            return _context.SyncLogs
                .Where(x => x.SyncDate.HasValue && x.SyncDate.Value.Date <= date.Date)
                .SelectMany(x => x.SyncLogItems)
                .Sum(i => (int?)i.Quantity) ?? 0;
        }

    }
}
