using D2R.Repositories;
using D2R.ViewModels;

namespace D2R.Services
{
    public class WarehouseInventoryService
    {
        private readonly WarehouseStockRepository _stockrepository;
        public WarehouseInventoryService()
        {
            _stockrepository = new WarehouseStockRepository();
        }

        public List<WarehouseStockDisplay> GetStockByWarehouse(int? warehouseId)
        {
            var stocks = _stockrepository.GetStocksByWarehouse(warehouseId);
            var items = _stockrepository.GetWarehouseItems();
            var categories = _stockrepository.GetItemCategories();

            var stockDisplays = stocks.Join(items, s => s.ItemId, i => i.ItemId, (s, i) => new { s, i })
                                      .Join(categories, si => si.i.CategoryId, c => c.CategoryId, (si, c) => new WarehouseStockDisplay
                                      {
                                          CategoryName = c.CategoryName,
                                          ItemName = si.i.Name,
                                          Quantity = si.s.Quantity ?? 0,
                                          Unit = si.i.Unit
                                      })
                                      .OrderBy(r => r.CategoryName)
                                      .ToList();

            return stockDisplays;

        }
    }
}
