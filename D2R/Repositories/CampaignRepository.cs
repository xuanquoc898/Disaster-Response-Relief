using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class CampaignRepository
    {
        private readonly DisasterReliefContext _context = new();

        public Campaign GetById(int id)
        {
            return _context.Campaigns.Include(c => c.Area)
                .Include(c => c.DisasterLevel)
                .ThenInclude(dl => dl.DisasterType)
                .FirstOrDefault(c => c.CampaignId == id);
        }

        public List<Campaign> GetAllWithRelations()
        {
            return _context.Campaigns
                .Include(c => c.Area)
                .Include(c => c.DisasterLevel).ThenInclude(dl => dl.DisasterType)
                .ToList();
        }

        public void Add(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
        }

        public void Update(Campaign campaign)
        {
            _context.Entry(campaign).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
