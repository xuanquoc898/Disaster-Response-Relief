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

        public List<WarehouseStockDisplay> GetStockByWarehouse(int warehouseId)
        {
            return _stockrepository.GetStockByWarehouse(warehouseId);
        }
    }
}
