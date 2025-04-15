using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class WarehouseStockRepository
    {
        private readonly DisasterReliefContext _context;

        public WarehouseStockRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<WarehouseStock> GetAll()
        {
            return _context.WarehouseStocks.ToList();
        }

        public WarehouseStock GetById(int id)
        {
            return _context.WarehouseStocks.Find(id);
        }

        public void Add(WarehouseStock entity)
        {
            _context.WarehouseStocks.Add(entity);
            _context.SaveChanges();
        }

        public void Update(WarehouseStock entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.WarehouseStocks.Find(id);
            if (entity != null)
            {
                _context.WarehouseStocks.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
