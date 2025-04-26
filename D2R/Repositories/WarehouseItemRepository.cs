using D2R.Models;
using Microsoft.EntityFrameworkCore;

namespace D2R.Repositories
{
    public class WarehouseItemRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseItemRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<WarehouseItem> GetAll()
        {
            return _context.WarehouseItems.ToList();
        }

        public WarehouseItem GetById(int id)
        {
            return _context.WarehouseItems.Find(id);
        }

        public void Add(WarehouseItem entity)
        {
            _context.WarehouseItems.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WarehouseItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.WarehouseItems.Find(id);
            if (entity != null)
            {
                _context.WarehouseItems.Remove(entity);
                _context.SaveChanges();
            }
        }
        public WarehouseItem? GetByItemId(int itemId)
        {
            return _context.WarehouseItems.FirstOrDefault(w => w.ItemId == itemId);
        }
    }
}
