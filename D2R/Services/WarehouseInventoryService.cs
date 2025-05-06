namespace D2R.Services
{
    public class WarehouseStockDisplay
    {
        public string? CategoryName { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
    }

    public class WarehouseInventoryService
    {
        private readonly WarehouseStockService _stockService;
        private readonly WarehouseItemService _itemService;
        private readonly ItemCategoryService _categoryService;

        public WarehouseInventoryService()
        {
            _stockService = new WarehouseStockService();
            _itemService = new WarehouseItemService();
            _categoryService = new ItemCategoryService();
        }

        public List<WarehouseStockDisplay> GetGroupedStockByWarehouse(int warehouseId)
        {
            var stocks = _stockService.GetAll()
                .Where(s => s.WarehouseId == warehouseId)
                .ToList();

            var items = _itemService.GetAll();
            var categories = _categoryService.GetAll();

            var result = stocks
                .Join(items, s => s.ItemId, i => i.ItemId, (s, i) => new { s, i })
                .Join(categories, si => si.i.CategoryId, c => c.CategoryId, (si, c) => new WarehouseStockDisplay
                {
                    CategoryName = c.CategoryName,
                    ItemName = si.i.Name,
                    Quantity = si.s.Quantity ?? 0,
                    Unit = si.i.Unit
                })
                .OrderBy(r => r.CategoryName)
                .ToList();

            return result;
        }
    }
}
