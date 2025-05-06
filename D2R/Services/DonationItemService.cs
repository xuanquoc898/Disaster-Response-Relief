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
        public void Add(DonationItem entity)
        {
            _repository.Add(entity);
        }
    }
}
