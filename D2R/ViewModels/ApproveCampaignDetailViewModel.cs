
using D2R.Models;
using D2R.Services;
using System.Collections.Generic;
using System.Linq;

namespace D2R.ViewModels
{
    public class ApproveCampaignDetailViewModel
    {
        private readonly CampaignService _campaignService = new();
        private readonly CampaignItemService _campaignItemService = new();
        private readonly WarehouseStockService _warehouseStockService = new();
        private readonly ItemCategoryService _itemCategoryService = new();
        private readonly DistributionLogService _logService = new();

        public Campaign Campaign { get; private set; }
        public List<CategoryGroup> GroupedItems { get; private set; }

        public void LoadGroupedByCategory(int campaignId)
        {
            Campaign = _campaignService.GetById(campaignId);
            var campaignItems = _campaignItemService.GetByCampaignId(campaignId);

            // Group items by category
            var grouped = campaignItems
                .GroupBy(ci => ci.Item.CategoryId)
                .Select(g => new CategoryGroup
                {
                    CategoryName = _itemCategoryService.GetById(g.Key ?? 0)?.CategoryName ?? "Không rõ",
                    Items = g.Select(i => new ItemEntry
                    {
                        ItemId = i.ItemId,
                        ItemName = i.Item?.Name ?? "Không tên",
                        QuantityRequested = i.QuantityRequested ?? 0,
                        QuantityAvailable = _warehouseStockService.GetQuantity(i.ItemId)
                    }).ToList()
                }).ToList();

            GroupedItems = grouped;
        }

        public bool CanDistribute()
        {
            return GroupedItems
                .SelectMany(g => g.Items)
                .All(i => i.QuantityAvailable >= i.QuantityRequested);
        }

        public void Distribute()
        {
            foreach (var item in GroupedItems.SelectMany(g => g.Items))
            {
                _warehouseStockService.Decrease(item.ItemId, item.QuantityRequested);

                _logService.Add(new DistributionLog
                {
                    CampaignId = Campaign.CampaignId,
                    ItemId = item.ItemId,
                    Quantity = item.QuantityRequested,
                    AreaId = Campaign.AreaId
                });
            }

            Campaign.Status = "Approved";
            _campaignService.Update(Campaign);
        }


        public void Reject()
        {
            Campaign.Status = "Rejected";
            _campaignService.Update(Campaign);
        }


        public class CategoryGroup
        {
            public string CategoryName { get; set; }
            public List<ItemEntry> Items { get; set; }
        }

        public class ItemEntry
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public int QuantityRequested { get; set; }
            public int QuantityAvailable { get; set; }
        }
    }
}
