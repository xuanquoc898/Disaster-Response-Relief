using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class CampaignService
    {
        private readonly CampaignRepository _repository = new();


        public Campaign GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Campaign> GetAllWithRelations()
        {
            return _repository.GetAllWithRelations();
        }
        public Dictionary<string, int> GetCampaignStatusCount(int month, int year)
        {
            return _repository.GetCampaignStatusGrouped(month, year);
        }
    }
}
