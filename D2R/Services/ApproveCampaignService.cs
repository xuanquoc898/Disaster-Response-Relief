using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class ApproveCampaignService
    {
        private readonly CampaignRepository _campaignRepository = new();
        private readonly CampaignItemRepository _campaignitemRepository = new();
        private readonly ItemCategoryRepository _itemcategoryRepository = new();
        private readonly DistributionLogRepository _distributionRepository = new();

        public Campaign GetCampaignById(int id)
        {
            return _campaignRepository.GetById(id);
        }

        public void UpdateCampaign(Campaign entity)
        {
            _campaignRepository.Update(entity);
        }
        public List<CampaignItem> GetByCampaignId(int campaignId)
        {
            return _campaignitemRepository.GetByCampaignIdWithItem(campaignId);
        }

        public ItemCategory GetItemCategoryById(int id)
        {
            return _itemcategoryRepository.GetById(id);
        }
        public void AddDistributionLog(DistributionLog entity)
        {
            _distributionRepository.Add(entity);
        }
    }
}
