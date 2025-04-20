using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class DonationItemService
    {
        private readonly DonationItemRepository _repository;

        public DonationItemService()
        {
            _repository = new DonationItemRepository();
        }

        public List<DonationItem> GetAll()
        {
            return _repository.GetAll();
        }

        public DonationItem GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(DonationItem entity)
        {
            _repository.Add(entity);
        }

        public void Update(DonationItem entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
