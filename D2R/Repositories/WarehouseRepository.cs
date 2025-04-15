using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public Warehouse GetById(int id)
        {
            return _context.Warehouses.Find(id);
        }

        public void Add(Warehouse entity)
        {
            _context.Warehouses.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Warehouse entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Warehouses.Find(id);
            if (entity != null)
            {
                _context.Warehouses.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
