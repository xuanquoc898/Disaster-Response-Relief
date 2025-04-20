using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class CampaignRepository
    {
        private readonly DisasterReliefContext _context;

        public CampaignRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<Campaign> GetAll()
        {
            return _context.Campaigns.ToList();
        }

        public Campaign GetById(int id)
        {
            return _context.Campaigns.Find(id);
        }

        public void Add(Campaign entity)
        {
            _context.Campaigns.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Campaign entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Campaigns.Find(id);
            if (entity != null)
            {
                _context.Campaigns.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
