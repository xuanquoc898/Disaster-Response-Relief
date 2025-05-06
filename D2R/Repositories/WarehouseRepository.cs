using D2R.Models;

namespace D2R.Repositories
{
    public class WarehouseRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseRepository()
        {
            _context = new DisasterReliefContext();
        }
        public List<Warehouse> GetAll()
        {
            return _context.Warehouses.ToList();
        }
    }
}
