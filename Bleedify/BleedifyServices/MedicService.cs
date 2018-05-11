using System.Collections.Generic;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
    class MedicService
    {
        private IRepository<int, Medic> _repository;

        public MedicService()
        {
            _repository = new MedicRepository(new MedicValidator());
        }

        public void Add(Medic entity)
        {
            _repository.Add(entity);
        }

        public Medic Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Medic> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Medic entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
