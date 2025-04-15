using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class DistributionLogService
    {
        private readonly DistributionLogRepository _repository;

        public DistributionLogService()
        {
            _repository = new DistributionLogRepository();
        }

        public List<DistributionLog> GetAll()
        {
            return _repository.GetAll();
        }

        public DistributionLog GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(DistributionLog entity)
        {
            _repository.Add(entity);
        }

        public void Update(DistributionLog entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
