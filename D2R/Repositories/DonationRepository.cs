using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class DonationRepository
    {
        private readonly DisasterReliefContext _context;

        public DonationRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<Donation> GetAll()
        {
            return _context.Donations.ToList();
        }

        public Donation GetById(int id)
        {
            return _context.Donations.Find(id);
        }

        public void Add(Donation entity)
        {
            _context.Donations.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Donation entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Donations.Find(id);
            if (entity != null)
            {
                _context.Donations.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
