using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class DonorRepository
    {
        private readonly DisasterReliefContext _context;

        public DonorRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<Donor> GetAll()
        {
            return _context.Donors.ToList();
        }

        public Donor GetById(int id)
        {
            return _context.Donors.Find(id);
        }

        public void Add(Donor entity)
        {
            _context.Donors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Donor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Donors.Find(id);
            if (entity != null)
            {
                _context.Donors.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
