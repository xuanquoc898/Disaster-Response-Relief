using D2R.Services;
namespace D2R.ViewModels
{
    public class WarehouseLocalViewModel
    {
        private readonly int _warehouseId;
        private readonly WarehouseInventoryService _inventoryService;

        public WarehouseLocalViewModel(int warehouseId)
        {
            _warehouseId = warehouseId;
            _inventoryService = new WarehouseInventoryService();
        }

        public List<WarehouseStockDisplay> GetGroupedStock()
        {
            return _inventoryService.GetStockByWarehouse(_warehouseId);
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