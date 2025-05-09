using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class ApproveCampaignDetailViewModel
    {
        private readonly ApproveCampaignService _approveCampaignService = new();
        private readonly WarehouseStockService _warehouseStockService = new();
        private readonly NotificationDetailService _notificationService = new();
        private readonly UserService _userService = new();
        public Campaign Campaign { get; private set; }
        public List<CategoryGroup> GroupedItems { get; private set; }
        public ApproveCampaignDetailViewModel()
        {
            GroupedItems = new List<CategoryGroup>();
        }

        public void LoadGroupedByCategory(int campaignId)
        {
            Campaign = _approveCampaignService.GetCampaignById(campaignId);
            var campaignItems = _approveCampaignService.GetByCampaignId(campaignId);

            var grouped = campaignItems
                .GroupBy(ci => ci.Item.CategoryId)
                .Select(g => new CategoryGroup
                {
                    CategoryName = _approveCampaignService.GetItemCategoryById(g.Key ?? 0)?.CategoryName ?? "Không rõ",
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

                _approveCampaignService.AddDistributionLog(new DistributionLog
                {
                    CampaignId = Campaign.CampaignId,
                    ItemId = item.ItemId,
                    Quantity = item.QuantityRequested,
                    AreaId = Campaign.AreaId
                });
            }

            Campaign.Status = "Approved";
            Campaign.ApprovedAt = DateTime.Now;
            _approveCampaignService.UpdateCampaign(Campaign);

            var staffList = _userService.GetStaffsByAreaId(Campaign.AreaId);

            foreach (var staff in staffList)
            {
                _notificationService.CreateNotification(
                userId: staff.UserId,
                campaignId: Campaign.CampaignId,
                content: "Chiến dịch \"{Campaign.Note}\" được duyệt."
            );

            }
        }
        public void Reject()
        {
            Campaign.Status = "Rejected";
            Campaign.RejectedAt = DateTime.Now;
            _approveCampaignService.UpdateCampaign(Campaign);

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
