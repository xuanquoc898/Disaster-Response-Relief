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

        public List<CampaignItem> GetAll()
        {
            return _context.CampaignItems.ToList();
        }

        public CampaignItem GetById(int id)
        {
            return _context.CampaignItems.Find(id);
        }

        public void Add(CampaignItem entity)
        {
            _context.CampaignItems.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CampaignItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.CampaignItems.Find(id);
            if (entity != null)
            {
                _context.CampaignItems.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
