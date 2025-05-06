using D2R.Models;

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
        public void Add(Donor entity)
        {
            _context.Donors.Add(entity);
            _context.SaveChanges();
        }
    }
}
