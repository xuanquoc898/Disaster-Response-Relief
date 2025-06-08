using D2R.Models;

namespace D2R.Repositories
{
    public class DisasterLevelRepository
    {
        private readonly DisasterReliefContext _context;

        public DisasterLevelRepository()
        {
            _context = new DisasterReliefContext();
        }
        public List<DisasterLevel> GetDisasterLevelsByType(int disasterTypeId)
        {
            return _context.DisasterLevels
                .Where(dl => dl.DisasterTypeId == disasterTypeId)
                .ToList();
        }
    }
}
