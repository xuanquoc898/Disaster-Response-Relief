using D2R.Models;

namespace D2R.Repositories
{
    public class SyncLogItemRepository
    {
        private readonly DisasterReliefContext _context;

        public SyncLogItemRepository()
        {
            _context = new DisasterReliefContext();
        }
        public void Add(SyncLogItem entity)
        {
            _context.SyncLogItems.Add(entity);
            _context.SaveChanges();
        }
    }
}
