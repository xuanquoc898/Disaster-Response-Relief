using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class WarehouseItemService
    {
        private readonly WarehouseItemRepository _repository;

        public WarehouseItemService()
        {
            _repository = new WarehouseItemRepository();
        }
        public List<WarehouseItem> GetAll()
        {
            return _repository.GetAll();
        }
        public List<WarehouseItem> GetByCategoryId(int categoryId)
        {
            return GetAll().Where(item => item.CategoryId == categoryId).ToList();
        }
    }
}
