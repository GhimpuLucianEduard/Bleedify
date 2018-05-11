using System.Collections.Generic;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;

namespace BleedifyServices
{
    class GrupaDeSangeService
    {
        private IRepository<int, GrupaDeSange> _repository;

        public GrupaDeSangeService()
        {
            _repository = new GrupaDeSangeRepository(new GrupaDeSangeValidator());
        }

        public IEnumerable<GrupaDeSange> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
