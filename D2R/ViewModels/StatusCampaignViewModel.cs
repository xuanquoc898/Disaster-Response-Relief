
using D2R.Models;
using D2R.Services;
using System.Collections.Generic;
using System.Linq;

namespace D2R.ViewModels
{
    public class StatusCampaignViewModel
    {
        private readonly CampaignService _campaignService = new();

        public List<Campaign> GetCampaignsByStatus(string status)
        {
            var all = _campaignService.GetAllWithRelations();
            return status == "Tất cả" ? all :
                   all.Where(c => c.Status == status).ToList();
        }
    }
}
