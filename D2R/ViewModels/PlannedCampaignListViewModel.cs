using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class PlannedCampaignListViewModel
    {
        private readonly CampaignService _campaignService = new();

        public List<Campaign> PlannedCampaigns { get; private set; }

        public PlannedCampaignListViewModel()
        {
            PlannedCampaigns = _campaignService.GetAllWithRelations()
                .Where(c => c.Status == "Planned")
                .ToList();
        }
    }
}
