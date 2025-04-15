using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

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

        public void Add(ItemCategory entity)
        {
            _repository.Add(entity);
        }

        public void Update(ItemCategory entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
