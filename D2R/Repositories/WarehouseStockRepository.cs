using D2R.Models;
using D2R.ViewModels;
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

        public WarehouseStock? GetByWarehouseIdItemId(int? warehouseId, int? itemId)
        {
            return GetAll()
                .FirstOrDefault(s => (!warehouseId.HasValue || s.WarehouseId == warehouseId) &&
                                     (!itemId.HasValue || s.ItemId == itemId));
        }

        public List<WarehouseStockDisplay> GetStockByWarehouse(int warehouseId)
        {
            var stocks = _context.WarehouseStocks
                .Where(s => s.WarehouseId == warehouseId)
                .Join(_context.WarehouseItems, s => s.ItemId, i => i.ItemId, (s, i) => new { s, i })
                .Join(_context.ItemCategories, si => si.i.CategoryId, c => c.CategoryId, (si, c) => new WarehouseStockDisplay
                {
                    CategoryName = c.CategoryName,
                    ItemName = si.i.Name,
                    Quantity = si.s.Quantity ?? 0,
                    Unit = si.i.Unit
                })
                .OrderBy(r => r.CategoryName)
                .ToList();
            return stocks;
        }

        public WarehouseStock? GetCentralStockByItemId(int itemId)
        {
            return _context.WarehouseStocks.FirstOrDefault(ws => ws.ItemId == itemId && ws.WarehouseId == null);
        }

        public List<WarehouseStock> GetStockById(int warehouseId)
        {
            return _context.WarehouseStocks.Where(s => s.WarehouseId == warehouseId).ToList();

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

        public List<WarehouseStock> GetStocksByWarehouse(int? warehouseId)
        {
            return _context.WarehouseStocks.Where(s => s.WarehouseId == warehouseId).ToList();
        }
        public List<WarehouseItem> GetWarehouseItems()
        {
            return _context.WarehouseItems.ToList();
        }
        public List<ItemCategory> GetItemCategories()
        {
            return _context.ItemCategories.ToList();
        }
    }
}
