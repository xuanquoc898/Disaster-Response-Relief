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

        public Warehouse? GetWarehouseByName(string? name)
        {
            return _context.Warehouses.FirstOrDefault(w => w.Name == name);
        }

        public void AddWarehouse(Warehouse entity)
        {
            _context.Warehouses.Add(entity);
            _context.SaveChanges();
        }
        public List<string> GetAll()
        {
            return _context.Warehouses.Select(w => w.Name).Distinct().ToList();
        }
        public List<Warehouse> GetAllWarehouses()
        {
            return _context.Warehouses.ToList();
        }

    }
}
