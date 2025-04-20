using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class SyncLogService
    {
        private readonly SyncLogRepository _repository;

        public SyncLogService()
        {
            _repository = new SyncLogRepository();
        }

        public List<SyncLog> GetAll()
        {
            return _repository.GetAll();
        }

        public SyncLog GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(SyncLog entity)
        {
            _repository.Add(entity);
        }

        public void Update(SyncLog entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
