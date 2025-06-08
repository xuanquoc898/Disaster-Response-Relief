using D2R.Models;

namespace D2R.Repositories
{
    public class AreaRepository
    {
        private readonly DisasterReliefContext _context;

        public AreaRepository()
        {
            _context = new DisasterReliefContext();
        }
    }
}
