using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class CreateCampaignService
    {
        private readonly DisasterTypeRepository _disastertypeRepository = new();
        private readonly DisasterLevelRepository _disasterlevelRepository = new();
        private readonly ItemCategoryRepository _itemcategoryRepository = new();
        private readonly WarehouseItemRepository _warehouseitemRepository = new();
        private readonly CampaignRepository _campaignRepository = new();
        private readonly CampaignItemRepository _campaignItemRepository = new();

        public List<DisasterType> GetAllDisasterType()
        {
            return _disastertypeRepository.GetAll();
        }

        public List<DisasterLevel> GetDisasterLevelsByType(int disasterTypeId)
        {
            return _disasterlevelRepository.GetDisasterLevelsByType(disasterTypeId);
        }

        public List<ItemCategory> GetAllItemCategory()
        {
            return _itemcategoryRepository.GetAll();
        }

        public List<WarehouseItem> GetItemsByCategory(int categoryId)
        {
            var items = _warehouseitemRepository.GetById(categoryId);

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                    item.Name = "Không tên";
            }
            return items;
        }

        public void AddCampaign(Campaign campaign)
        {
            _campaignRepository.Add(campaign);
        }

        public void AddCampaignItems(List<CampaignItem> campaignItems)
        {
            _campaignItemRepository.AddCampaignItems(campaignItems);
        }

        public void AddCampaignItem(CampaignItem campaignItem)
        {
            _campaignItemRepository.Add(campaignItem);
        }
    }
}
