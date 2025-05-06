using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _repository;

        public CampaignService()
        {
            _repository = new CampaignRepository();
        }
        public Campaign GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Campaign entity)
        {
            _repository.Add(entity);
        }

        public void Update(Campaign entity)
        {
            _repository.Update(entity);
        }
        public List<Campaign> GetAllWithRelations()
        {
            return _repository.GetAllWithRelations();
        }
    }
}
