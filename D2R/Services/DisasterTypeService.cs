using D2R.Models;
using D2R.Repositories;
using System.Collections.Generic;

namespace D2R.Services
{
    public class DisasterTypeService
    {
        private readonly DisasterTypeRepository _repository;

        public DisasterTypeService()
        {
            _repository = new DisasterTypeRepository();
        }

        public List<DisasterType> GetAll()
        {
            return _repository.GetAll();
        }

        public DisasterType GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(DisasterType entity)
        {
            _repository.Add(entity);
        }

        public void Update(DisasterType entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
