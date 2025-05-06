using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class ApproveCampaignDetailViewModel
    {
        private readonly CampaignService _campaignService = new();
        private readonly CampaignItemService _campaignItemService = new();
        private readonly WarehouseStockService _warehouseStockService = new();
        private readonly ItemCategoryService _itemCategoryService = new();
        private readonly DistributionLogService _logService = new();
        private readonly NotificationDetailService _notificationService = new();
        private readonly UserService _userService = new();

        public Campaign Campaign { get; private set; }
        public List<CategoryGroup> GroupedItems { get; private set; }

        public void LoadGroupedByCategory(int campaignId)
        {
            Campaign = _campaignService.GetById(campaignId);
            var campaignItems = _campaignItemService.GetByCampaignId(campaignId);

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
            Campaign.ApprovedAt = DateTime.Now;
            _campaignService.Update(Campaign);

            var staffList = _userService.GetStaffsByAreaId(Campaign.AreaId);

            foreach (var staff in staffList)
            {
                _notificationService.CreateNotification(
                userId: staff.UserId,
                campaignId: Campaign.CampaignId,
                content: "Chiến dịch được duyệt."
            );

            }

        }
        public void Reject()
        {
            Campaign.Status = "Rejected";
            Campaign.RejectedAt = DateTime.Now;
            _campaignService.Update(Campaign);

            var staffList = _userService.GetStaffsByAreaId(Campaign.AreaId);

            foreach (var staff in staffList)
            {
                _notificationService.CreateNotification(
                userId: staff.UserId,
                campaignId: Campaign.CampaignId,
                content: $"Chiến dịch \"{Campaign.Note}\" đã bị từ chối."
            );

            }
        }
        public class CategoryGroup
        {
            public string CategoryName { get; set; }
            public List<ItemEntry> Items { get; set; }
        }

        public class ItemEntry
        {
            public int ItemId { get; set; }
            public string? ItemName { get; set; }
            public int QuantityRequested { get; set; }
            public int QuantityAvailable { get; set; }
        }
    }
}
