using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class SyncLogItemService
    {
        private readonly SyncLogItemRepository _repository;

        public SyncLogItemService()
        {
            _repository = new SyncLogItemRepository();
        }
        public void Add(SyncLogItem entity)
        {
            _repository.Add(entity);
        }
    }
}
