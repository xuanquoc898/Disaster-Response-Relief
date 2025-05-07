using D2R.Models;

namespace D2R.Repositories
{
    public class WarehouseItemRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseItemRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<WarehouseItem> GetById(int id)
        {
            return _context.WarehouseItems.Where(i => i.CategoryId == id).ToList();
        }
    }
}
