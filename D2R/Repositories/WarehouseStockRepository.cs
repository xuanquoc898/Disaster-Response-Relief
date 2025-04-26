using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class WarehouseStockRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseStockRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<WarehouseStock> GetAll()
        {
            return _context.WarehouseStocks.ToList();
        }
        public List<WarehouseStock> GetAllWithWarehouse()
        {
            return _context.WarehouseStocks
                .Include(s => s.Warehouse)
                .ToList();
        }

        public WarehouseStock GetById(int id)
        {
            return _context.WarehouseStocks.Find(id);
        }

        public void Add(WarehouseStock entity)
        {
            _context.WarehouseStocks.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WarehouseStock entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.WarehouseStocks.Find(id);
            if (entity != null)
            {
                _context.WarehouseStocks.Remove(entity);
                _context.SaveChanges();
            }
        }
        public void SyncWarehouseFromDistribution(int campaignId, int warehouseId)
        {
            var distributions = _context.DistributionLogs
                .Where(d => d.CampaignId == campaignId)
                .ToList();

            foreach (var dist in distributions)
            {
                var existingStock = _context.WarehouseStocks
                    .FirstOrDefault(ws => ws.WarehouseId == warehouseId && ws.ItemId == dist.ItemId);

                if (existingStock != null)
                {
                    existingStock.Quantity += dist.Quantity ?? 0;
                }
                else
                {
                    _context.WarehouseStocks.Add(new WarehouseStock
                    {
                        WarehouseId = warehouseId,
                        ItemId = dist.ItemId,
                        Quantity = dist.Quantity ?? 0,
                        LastUpdated = DateTime.Now
                    });
                }
            }

            _context.SaveChanges();
        }

    }
}
