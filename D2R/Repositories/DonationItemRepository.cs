using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class DonationItemRepository
    {
        private readonly DisasterReliefContext _context;

        public DonationItemRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<DonationItem> GetAll()
        {
            return _context.DonationItems.ToList();
        }

        public DonationItem GetById(int id)
        {
            return _context.DonationItems.Find(id);
        }

        public void Add(DonationItem entity)
        {
            _context.DonationItems.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DonationItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DonationItems.Find(id);
            if (entity != null)
            {
                _context.DonationItems.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
