using D2R.Models;

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
    }
}
