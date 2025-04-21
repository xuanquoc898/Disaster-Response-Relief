
using D2R.Helpers;
using D2R.Models;
using D2R.Services;
using D2R.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace D2R.ViewModels
{
    public class CampaignItemRequestModel
    {
        public int? CategoryId { get; set; }
        public int? ItemId { get; set; }
        public int? QuantityRequested { get; set; }
    }

    public class CreateCampaignViewModel
    {
        private readonly DisasterTypeService _disasterTypeService = new();
        private readonly DisasterLevelService _disasterLevelService = new();
        private readonly ItemCategoryService _itemCategoryService = new();
        private readonly WarehouseItemService _warehouseItemService = new();
        private readonly CampaignService _campaignService = new();
        private readonly CampaignItemService _campaignItemService = new();

        private readonly List<CampaignCategoryGroupControl> _groupControls = new();

        public int? DisasterLevelId { get; set; }
        public string? Note { get; set; }

        public void AddGroup(CampaignCategoryGroupControl group)
        {
            _groupControls.Add(group);
        }

        public void ClearGroups()
        {
            _groupControls.Clear();
        }

        public List<DisasterType> GetDisasterTypes()
        {
            return _disasterTypeService.GetAll();
        }

        public List<DisasterLevel> GetDisasterLevelsByType(int disasterTypeId)
        {
            return _disasterLevelService.GetAll().Where(l => l.DisasterTypeId == disasterTypeId).ToList();
        }

        public List<ItemCategory> GetCategories()
        {
            return _itemCategoryService.GetAll();
        }
        public List<WarehouseItem> GetItemsByCategory(int categoryId)
        {
            var items = _warehouseItemService.GetByCategoryId(categoryId);

            // Đảm bảo có tên để hiển thị
            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.Name))
                    item.Name = "Không tên";
            }

            return items;
        }


        public bool SubmitCampaign()
        {
            var allRequestedItems = _groupControls.SelectMany(g => g.GetRequestedItems()).ToList();

            if (DisasterLevelId == null || allRequestedItems.Count == 0 ||
                allRequestedItems.Any(x => x.ItemId == null || x.QuantityRequested == null))
                return false;

            var campaign = new Campaign
            {
                AreaId = LoginSession.CurrentUser.AreaId ?? 0,
                DisasterLevelId = DisasterLevelId,
                CreatedDate = DateTime.Now,
                Status = "Planned",
                Note = Note
            };

            _campaignService.Add(campaign);

            foreach (var request in allRequestedItems)
            {
                _campaignItemService.Add(new CampaignItem
                {
                    CampaignId = campaign.CampaignId,
                    ItemId = request.ItemId ?? 0,
                    QuantityRequested = request.QuantityRequested,
                    QuantityApproved = null
                });
            }

            return true;
        }
    }
}
