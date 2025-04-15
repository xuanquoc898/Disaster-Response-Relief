using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class DistributionLogRepository
    {
        private readonly DisasterReliefContext _context;

        public DistributionLogRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<DistributionLog> GetAll()
        {
            return _context.DistributionLogs.ToList();
        }

        public DistributionLog GetById(int id)
        {
            return _context.DistributionLogs.Find(id);
        }

        public void Add(DistributionLog entity)
        {
            _context.DistributionLogs.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DistributionLog entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DistributionLogs.Find(id);
            if (entity != null)
            {
                _context.DistributionLogs.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
