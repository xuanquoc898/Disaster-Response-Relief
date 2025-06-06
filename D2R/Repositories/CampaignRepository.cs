using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Trả về danh sách chiến dịch trong một tháng và năm
        public List<Campaign> GetCampaignsByMonthYear(int month, int year)
        {
            return _context.Campaigns
                .Where(c => c.CreatedDate.HasValue &&
                            c.CreatedDate.Value.Month == month &&
                            c.CreatedDate.Value.Year == year)
                .ToList();
        }

        // Trả về tổng số chiến dịch theo tháng, năm
        public int GetTotalCampaignCount(int month, int year)
        {
            return _context.Campaigns
                .Count(c => c.CreatedDate.HasValue &&
                            c.CreatedDate.Value.Month == month &&
                            c.CreatedDate.Value.Year == year);
        }

        // Trả về số lượng chiến dịch theo trạng thái trong tháng/năm
        public Dictionary<string, int> GetCampaignStatusGrouped(int month, int year)
        {
            return _context.Campaigns
                .Where(c => c.CreatedDate.HasValue &&
                            c.CreatedDate.Value.Month == month &&
                            c.CreatedDate.Value.Year == year)
                .GroupBy(c => c.Status ?? "Không rõ")
                .ToDictionary(g => g.Key, g => g.Count());
        }


    }
}
