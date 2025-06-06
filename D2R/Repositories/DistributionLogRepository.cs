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
        public int GetTotalOutboundUpToDate(DateTime date)
        {
            return _context.DistributionLogs
                .Where(x => x.DistributionDate.HasValue && x.DistributionDate.Value.Date <= date.Date)
                .Sum(x => (int?)x.Quantity) ?? 0;
        }

    }
}
