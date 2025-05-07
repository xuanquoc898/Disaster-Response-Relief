using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class SyncLogItemRepository
    {
        private readonly DisasterReliefContext _context;

        public SyncLogItemRepository()
        {
            _context = new DisasterReliefContext();
        }
        public void Add(SyncLogItem entity)
        {
            _context.SyncLogItems.Add(entity);
            _context.SaveChanges();
        }
        public List<DistributionLog> GetDistributionsByCampaign(int campaignId)
        {
            return _context.DistributionLogs.Where(d => d.CampaignId == campaignId).ToList();
        }

        public WarehouseStock? GetWarehouseStock(int warehouseId, int? itemId)
        {
            return _context.WarehouseStocks.FirstOrDefault(ws => ws.WarehouseId == warehouseId && ws.ItemId == itemId);
        }

        public void AddWarehouseStock(WarehouseStock stock)
        {
            _context.WarehouseStocks.Add(stock);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
