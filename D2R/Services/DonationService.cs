using D2R.Models;
using D2R.Repositories;

namespace D2R.Services
{
    public class DonationService
    {
        private readonly DonationRepository _repository;

        public DonationService()
        {
            _repository = new DonationRepository();
        }
        public void Add(Donation entity)
        {
            _repository.Add(entity);
        }
    }
}
