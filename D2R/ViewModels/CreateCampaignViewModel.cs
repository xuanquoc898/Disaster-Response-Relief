using D2R.Helpers;
using D2R.Models;
using D2R.Services;
using D2R.Views.Users;

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
        private readonly CreateCampaignService _createCampaignService;
        private readonly UserService _userService;
        private readonly NotificationDetailService _notificationService;


        private readonly List<CampaignCategoryGroupControl> _groupControls = new();
        public int? DisasterLevelId { get; set; }
        public string? Title { get; set; }


        public CreateCampaignViewModel()
        {
            _createCampaignService = new CreateCampaignService();
            _userService = new UserService();
            _notificationService = new NotificationDetailService();
        }
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
            return _createCampaignService.GetAllDisasterType();
        }

        public List<DisasterLevel> GetDisasterLevelsByType(int disasterTypeId)
        {
            return _createCampaignService.GetDisasterLevelsByType(disasterTypeId);
        }

        public List<ItemCategory> GetCategories()
        {
            return _createCampaignService.GetAllItemCategory();
        }

        public List<WarehouseItem> GetItemsByCategory(int categoryId)
        {
            return _createCampaignService.GetItemsByCategory(categoryId);


        }


        public bool SubmitCampaign()
        {
            var allRequestedItems = _groupControls.SelectMany(g => g.GetRequestedItems()).ToList();

            if (DisasterLevelId == null || allRequestedItems.Count == 0 ||
                allRequestedItems.Any(x => x.ItemId == null || x.QuantityRequested == null || x.QuantityRequested <= 0))
                return false;
            var campaign = new Campaign
            {
                AreaId = LoginSession.CurrentUser.AreaId ?? 0,
                DisasterLevelId = DisasterLevelId,
                CreatedDate = DateTime.Now,
                Status = "Planned",
                Title = Title
            };


            _createCampaignService.AddCampaign(campaign);

            var mergedItems = allRequestedItems
                .Where(x => x.ItemId != null)
                .GroupBy(x => x.ItemId)
                .Select(g => new CampaignItemRequestModel
                {
                    ItemId = g.Key,
                    QuantityRequested = g.Sum(x => x.QuantityRequested ?? 0)
                })
                .ToList();

            foreach (var request in mergedItems)
            {
                _createCampaignService.AddCampaignItem(new CampaignItem
                {
                    CampaignId = campaign.CampaignId,
                    ItemId = request.ItemId ?? 0,
                    QuantityRequested = request.QuantityRequested
                });
            }



            var admins = _userService.GetAdmins();

            foreach (var admin in admins)
            {
                _notificationService.CreateNotification(
                    userId: admin.UserId,
                    campaignId: campaign.CampaignId,
                    content: $"● Chiến dịch \"{campaign.Title}\" vừa gửi yêu cầu duyệt."
                );
            }
            return true;
        }

    }
}
