using System.Collections.Generic;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
    public class GrupaDeSangeService
    {
        private IRepository<int, GrupaDeSange> _repository;

        public GrupaDeSangeService()
        {
            _repository = new GrupaDeSangeRepository(new GrupaDeSangeValidator());
        }

        public GrupaDeSange Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<GrupaDeSange> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
