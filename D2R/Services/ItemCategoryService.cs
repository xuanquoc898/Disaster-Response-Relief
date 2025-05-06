using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class ItemCategoryService
    {
        private readonly ItemCategoryRepository _repository;

        public ItemCategoryService()
        {
            _repository = new ItemCategoryRepository();
        }

        public List<ItemCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public ItemCategory GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
