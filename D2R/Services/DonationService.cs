using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class DonationService
    {
        private readonly DonationRepository _repository;

        public DonationService()
        {
            _repository = new DonationRepository();
        }

        public List<Donation> GetAll()
        {
            return _repository.GetAll();
        }

        public Donation GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Donation entity)
        {
            _repository.Add(entity);
        }

        public void Update(Donation entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
