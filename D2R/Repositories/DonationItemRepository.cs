using D2R.Models;

namespace D2R.Repositories
{
    public class DonationItemRepository
    {
        private readonly DisasterReliefContext _context;

        public DonationItemRepository()
        {
            _context = new DisasterReliefContext();
        }
        public void Add(DonationItem entity)
        {
            _context.DonationItems.Add(entity);
            _context.SaveChanges();
        }
    }
}
