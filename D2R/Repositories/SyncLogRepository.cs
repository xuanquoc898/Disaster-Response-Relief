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
    }
}
