using D2R.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace D2R.Repositories
{
    public class ItemCategoryRepository
    {
        private readonly DisasterReliefContext _context;

        public ItemCategoryRepository()
        {
            _context = new DisasterReliefContext();
        }

        public List<ItemCategory> GetAll()
        {
            return _context.ItemCategories.ToList();
        }

        public ItemCategory GetById(int id)
        {
            return _context.ItemCategories.Find(id);
        }

        public void Add(ItemCategory entity)
        {
            _context.ItemCategories.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ItemCategory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.ItemCategories.Find(id);
            if (entity != null)
            {
                _context.ItemCategories.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
