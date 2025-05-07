using D2R.Models;
using D2R.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R.Services
{
    public class ApproveCampaignService
    {
        private readonly CampaignRepository _campaignRepository;
        private readonly CampaignItemRepository _campaignitemRepository;
        private readonly ItemCategoryRepository _itemcategoryRepository;
        private readonly DistributionLogRepository _distributionRepository;
        public ApproveCampaignService()
        {
            _campaignRepository = new CampaignRepository();
            _campaignitemRepository = new CampaignItemRepository();
            _itemcategoryRepository = new ItemCategoryRepository();
            _distributionRepository = new DistributionLogRepository();
        }
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
