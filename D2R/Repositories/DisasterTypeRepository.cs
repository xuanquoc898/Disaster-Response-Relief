using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class DisasterTypeRepository
    {
        private readonly DisasterReliefContext _context;

        public DisasterTypeRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<DisasterType> GetAll()
        {
            return _context.DisasterTypes.ToList();
        }

        public DisasterType GetById(int id)
        {
            return _context.DisasterTypes.Find(id);
        }

        public void Add(DisasterType entity)
        {
            _context.DisasterTypes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DisasterType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DisasterTypes.Find(id);
            if (entity != null)
            {
                _context.DisasterTypes.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
