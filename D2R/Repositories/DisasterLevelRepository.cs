using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class DisasterLevelRepository
    {
        private readonly DisasterReliefContext _context;

        public DisasterLevelRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<DisasterLevel> GetAll()
        {
            return _context.DisasterLevels.ToList();
        }

        public DisasterLevel GetById(int id)
        {
            return _context.DisasterLevels.Find(id);
        }

        public void Add(DisasterLevel entity)
        {
            _context.DisasterLevels.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DisasterLevel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DisasterLevels.Find(id);
            if (entity != null)
            {
                _context.DisasterLevels.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
