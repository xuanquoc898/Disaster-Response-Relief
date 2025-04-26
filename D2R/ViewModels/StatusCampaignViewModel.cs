
using D2R.Models;
using D2R.Services;

namespace D2R.ViewModels
{
    public class StatusCampaignViewModel
    {
        private readonly CampaignService _campaignService = new();

        public List<Campaign> GetCampaignsByStatus(string status)
        {
            var all = _campaignService.GetAllWithRelations();

            if (status == "Tất cả")
            {
                return all;
            }
            else
            {
                return all.Where(c => c.Status == status).ToList();
            }
        }

    }
}
