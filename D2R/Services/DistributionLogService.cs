using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class DistributionLogService
    {
        private readonly DistributionLogRepository _repository;

        public DistributionLogService()
        {
            _repository = new DistributionLogRepository();
        }
        public void Add(DistributionLog entity)
        {
            _repository.Add(entity);
        }
    }
}
