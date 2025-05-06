using D2R.Models;

namespace D2R.Repositories
{
    public class DonationRepository
    {
        private readonly DisasterReliefContext _context;

        public DonationRepository()
        {
            _context = new DisasterReliefContext();
        }
        public void Add(Donation entity)
        {
            _context.Donations.Add(entity);
            _context.SaveChanges();
        }
    }
}
