using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class SyncLogItemService
    {
        private readonly SyncLogItemRepository _repository;

        public SyncLogItemService()
        {
            _repository = new SyncLogItemRepository();
        }

        public List<SyncLogItem> GetAll()
        {
            return _repository.GetAll();
        }

        public SyncLogItem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(SyncLogItem entity)
        {
            _repository.Add(entity);
        }

        public void Update(SyncLogItem entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
