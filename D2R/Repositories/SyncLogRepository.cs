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
            return _context.SyncLogs.ToList();
        }

        public SyncLog GetById(int id)
        {
            return _context.SyncLogs.Find(id);
        }

        public void Add(SyncLog entity)
        {
            _context.SyncLogs.Add(entity);
            _context.SaveChanges();
        }

        public void Update(SyncLog entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.SyncLogs.Find(id);
            if (entity != null)
            {
                _context.SyncLogs.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
