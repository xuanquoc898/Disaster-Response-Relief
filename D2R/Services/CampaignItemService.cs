using D2R.Models;
using D2R.Repositories;
using Microsoft.EntityFrameworkCore;

namespace D2R.Services
{
    public class CampaignItemService
    {
        private readonly CampaignItemRepository _repository;

        public CampaignItemService()
        {
            _repository = new CampaignItemRepository();
        }

        public List<CampaignItem> GetAll()
        {
            return _repository.GetAll();
        }

        public CampaignItem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(CampaignItem entity)
        {
            _repository.Add(entity);
        }

        public void Update(CampaignItem entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public List<CampaignItem> GetByCampaignId(int campaignId)
        {
            return _repository.GetByCampaignIdWithItem(campaignId);
        }
    }
}
