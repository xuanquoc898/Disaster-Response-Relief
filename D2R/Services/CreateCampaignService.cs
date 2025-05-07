using D2R.Models;
using D2R.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace D2R.Services
{
    public class CreateCampaignService
    {
        private readonly DisasterTypeRepository _disastertypeRepository;
        private readonly DisasterLevelRepository _disasterlevelRepository;
        private readonly ItemCategoryRepository _itemcategoryRepository;
        private readonly WarehouseItemRepository _warehouseitemRepository;
        private readonly CampaignRepository _campaignRepository;
        private readonly CampaignItemRepository _campaignItemRepository;
        public CreateCampaignService()
        {
            _disastertypeRepository = new DisasterTypeRepository();
            _disasterlevelRepository = new DisasterLevelRepository();
            _itemcategoryRepository = new ItemCategoryRepository();
            _warehouseitemRepository = new WarehouseItemRepository();
            _campaignRepository = new CampaignRepository();
            _campaignItemRepository = new CampaignItemRepository();
        }

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

        public void AddCampaignItem(CampaignItem campaignItem)
        {
            _campaignItemRepository.Add(campaignItem);
        }
    }
}
