using D2R.Models;

namespace D2R.Repositories
{
    public class DistributionLogRepository
    {
        private readonly DisasterReliefContext _context = new DisasterReliefContext();

        public void Add(DistributionLog entity)
        {
            _context.DistributionLogs.Add(entity);
            _context.SaveChanges();
        }
    }
}
