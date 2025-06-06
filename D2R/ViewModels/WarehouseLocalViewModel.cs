using D2R.Services;
namespace D2R.ViewModels
{
    public class WarehouseLocalViewModel
    {
        private readonly int? _warehouseId;
        private readonly WarehouseInventoryService _inventoryService;

        public WarehouseLocalViewModel(int? warehouseId)
        {
            _warehouseId = warehouseId;
            _inventoryService = new WarehouseInventoryService();
        }

        public List<WarehouseStockDisplay> GetGroupedStock()
        {
            return _inventoryService.GetStockByWarehouse(_warehouseId);
        }

        public List<string> GetAllCategories()
        {
            return _inventoryService.GetItemCategories()
                .Select(c => c.CategoryName!)
                .Distinct()
                .OrderBy(n => n)
                .Prepend("Tất cả")
                .ToList();
        }

        public List<string> GetItemNamesByCategory(string category)
        {
            var items = _inventoryService.GetWarehouseItems();
            if (category == "Tất cả")
                return items.Select(i => i.Name!).Distinct().OrderBy(n => n).Prepend("Tất cả").ToList();

            return items
                .Where(i => i.Category?.CategoryName == category)
                .Select(i => i.Name!)
                .Distinct()
                .OrderBy(n => n)
                .Prepend("Tất cả")
                .ToList();
        }

        public List<WarehouseStockDisplay> GetFilteredStock(string category, string itemName)
        {
            return GetGroupedStock()
                .Where(x =>
                    (category == "Tất cả" || x.CategoryName == category) &&
                    (itemName == "Tất cả" || x.ItemName == itemName))
                .ToList();
        }


    }

    public class WarehouseStockDisplay
    {
        public string? CategoryName { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
    }
}