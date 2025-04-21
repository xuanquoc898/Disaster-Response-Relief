using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class AreaRepository
    {
        private readonly DisasterReliefContext _context;

        public AreaRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<Area> GetAll()
        {
            return _context.Areas.ToList();
        }

        public Area GetById(int id)
        {
            return _context.Areas.Find(id);
        }

        public void Add(Area entity)
        {
            _context.Areas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Area entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Areas.Find(id);
            if (entity != null)
            {
                _context.Areas.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
