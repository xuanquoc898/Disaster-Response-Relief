using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class SyncLogItemRepository
    {
        private readonly DisasterReliefContext _context;

        public SyncLogItemRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<SyncLogItem> GetAll()
        {
            return _context.SyncLogItems.ToList();
        }

        public SyncLogItem GetById(int id)
        {
            return _context.SyncLogItems.Find(id);
        }

        public void Add(SyncLogItem entity)
        {
            _context.SyncLogItems.Add(entity);
            _context.SaveChanges();
        }

        public void Update(SyncLogItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.SyncLogItems.Find(id);
            if (entity != null)
            {
                _context.SyncLogItems.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
