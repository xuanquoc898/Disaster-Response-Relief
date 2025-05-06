using D2R.Models;

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
    }
}
