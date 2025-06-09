using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class CampaignItemRepository
    {
        private readonly DisasterReliefContext _context;

        public CampaignItemRepository()
        {
            _context = new DisasterReliefContext();
        }

        public void AddCampaignItems(List<CampaignItem> campaignItems)
        {
            _context.CampaignItems.AddRange(campaignItems);
            _context.SaveChanges();
        }

        public void Add(CampaignItem entity)
        {
            _context.CampaignItems.Add(entity);
            _context.SaveChanges();
        }
        public List<CampaignItem> GetByCampaignIdWithItem(int campaignId)
        {
            return _context.CampaignItems
                .Where(ci => ci.CampaignId == campaignId)
                .Include(ci => ci.Item)
                .ThenInclude(i => i.Category)
                .ToList();
        }
    }
}
