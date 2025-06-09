using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class CampaignItemService
    {
        private readonly CampaignItemRepository _repository = new();

        public List<CampaignItem> GetByCampaignId(int campaignId)
        {
            return _repository.GetByCampaignIdWithItem(campaignId);
        }
    }
}
